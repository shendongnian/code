        [TestMethod()]
        public void ToCamelCaseTest()
        {
            var testData = new string[] { "AAACamel", "AAA", "SplitThisByCamel", "AnA", "doesnothing", "a", "A", "aasdasdAAA" };
            var expectedData = new string[] { "AAA Camel", "AAA", "Split This By Camel", "An A", "doesnothing", "a", "A", "aasdasd AAA" };
            for (int i = 0; i < testData.Length; i++)
            {
                var actual = testData[i].SeperateByCamelCase();
                var expected = expectedData[i];
                Assert.AreEqual(actual, expected);
            }
        }
