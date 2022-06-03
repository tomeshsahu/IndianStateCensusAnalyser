using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensualAnalyerTest
{
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\WrongIndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"E:\IndianStateCensusAnalyzer\IndianStateCensusAnalyser\CensualAnalyerTest\CsvFiles\WrongIndiaStateCode.csv";
        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}