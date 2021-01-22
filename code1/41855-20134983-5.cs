    [TestClass]
    public class UriHelperTest
    {
        [TestMethod]
        public void DecodeQueryParameters()
        {
            DecodeQueryParametersTest("http://test/test.html", new Dictionary<string, string>());
            DecodeQueryParametersTest("http://test/test.html?", new Dictionary<string, string>());
            DecodeQueryParametersTest("http://test/test.html?key=bla/blub.xml", new Dictionary<string, string> { { "key", "bla/blub.xml" } });
            DecodeQueryParametersTest("http://test/test.html?eins=1&zwei=2", new Dictionary<string, string> { { "eins", "1" }, { "zwei", "2" } });
            DecodeQueryParametersTest("http://test/test.html?empty", new Dictionary<string, string> { { "empty", "" } });
            DecodeQueryParametersTest("http://test/test.html?empty=", new Dictionary<string, string> { { "empty", "" } });
            DecodeQueryParametersTest("http://test/test.html?key=1&", new Dictionary<string, string> { { "key", "1" } });
            DecodeQueryParametersTest("http://test/test.html?key=value?&b=c", new Dictionary<string, string> { { "key", "value?" }, { "b", "c" } });
            DecodeQueryParametersTest("http://test/test.html?key=value=what", new Dictionary<string, string> { { "key", "value=what" } });
            DecodeQueryParametersTest("http://www.google.com/search?q=energy+edge&rls=com.microsoft:en-au&ie=UTF-8&oe=UTF-8&startIndex=&startPage=1%22",
                new Dictionary<string, string>
                {
                    { "q", "energy+edge" },
                    { "rls", "com.microsoft:en-au" },
                    { "ie", "UTF-8" },
                    { "oe", "UTF-8" },
                    { "startIndex", "" },
                    { "startPage", "1%22" },
                });
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
    }
