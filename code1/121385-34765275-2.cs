    namespace TinyCsvParser.Test
    {
        [TestFixture]
        public class TinyCsvParserTest
        {
            [Test]
            public void TinyCsvTest()
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, new[] { ';' });
                CsvPersonMapping csvMapper = new CsvPersonMapping();
                CsvParser<Person> csvParser = new CsvParser<Person>(csvParserOptions, csvMapper);
                var result = csvParser
                    .ReadFromFile(@"persons.csv", Encoding.ASCII)
                    .ToList();
                Assert.AreEqual(2, result.Count);
    
                Assert.IsTrue(result.All(x => x.IsValid));
    			
                Assert.AreEqual("Philipp", result[0].Result.FirstName);
                Assert.AreEqual("Wagner", result[0].Result.LastName);
                Assert.AreEqual(1986, result[0].Result.BirthDate.Year);
                Assert.AreEqual(5, result[0].Result.BirthDate.Month);
                Assert.AreEqual(12, result[0].Result.BirthDate.Day);
    
                Assert.AreEqual("Max", result[1].Result.FirstName);
                Assert.AreEqual("Mustermann", result[1].Result.LastName);
    
                Assert.AreEqual(2014, result[1].Result.BirthDate.Year);
                Assert.AreEqual(1, result[1].Result.BirthDate.Month);
                Assert.AreEqual(1, result[1].Result.BirthDate.Day);
            }
        }
    }
