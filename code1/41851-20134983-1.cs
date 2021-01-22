    [TestClass]
    public class UriHelperTest
    {
        [TestMethod]
        public void DecodeQueryParameters()
        {
            DecodeQueryParametersTest("http://localhost/file?path=bla/blub.xml", new Dictionary<string, string> { { "path", "bla/blub.xml" } });
            DecodeQueryParametersTest("http://localhost/path?eins=1&zwei=2", new Dictionary<string, string> { { "eins", "1" }, { "zwei", "2" } });
            DecodeQueryParametersTest("http://localhost/path", new Dictionary<string, string>());
            DecodeQueryParametersTest<FormatException>("http://localhost/path?");
            DecodeQueryParametersTest<FormatException>("http://localhost/topic?id");
            DecodeQueryParametersTest<FormatException>("http://localhost/topic?id=");
            DecodeQueryParametersTest<FormatException>("http://localhost/topic?id=1&");
        }
        private static void DecodeQueryParametersTest(string uri, Dictionary<string, string> expected)
        {
            IDictionary<string, string> parameters = new Uri(uri).DecodeQueryParameters();
            Assert.AreEqual(expected.Count, parameters.Count, "Wrong parameter count. Uri: {0}", uri);
            foreach (var key in expected.Keys)
            {
                Assert.IsTrue(parameters.ContainsKey(key), "Missing parameter key {0}. Uri: {1}", key, uri);
                Assert.AreEqual(expected[key], parameters[key], "Wrong parameter value for {0}. Uri: {1}", parameters[key], uri);
            }
        }
        private static void DecodeQueryParametersTest<TException>(string uri) where TException : Exception
        {
            try
            {
                new Uri(uri).DecodeQueryParameters();
                Assert.Fail("Expected {0} was not thrown. Uri: {1}", typeof(TException).Name, uri);
            }
            catch (TException) { }
        }
    }
