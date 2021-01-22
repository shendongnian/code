    public class TestSuiteParser : ITestSuiteParser {
        private TestSuite testSuite;
        public TestSuitParser(TestSuit testSuite) {
            this.testSuite = testSuite;
        }
        TestSuite Parse(XPathNavigator someXml)
        {
            List<XPathNavigator> aListOfNodes = DoSomeThingToGetNodes(someXml)
            foreach (XPathNavigator blah in aListOfNodes)
            {
                //I don't understand what you are trying to do here?
                TestCase testCase = ??? // I want to get this from my Unity Container
                testSuite.TestCase.Add(testCase);
            } 
        }
    }
