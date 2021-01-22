    public class TestSuiteParser
    {
        private readonly TestSuite testSuite;
        private readonly TestCase testCase;
        public TestSuiteParser(TestSuite testSuite, TestCase testCase)
        {
            if(testSuite == null)
            {
                throw new ArgumentNullException(testSuite);
            }
            if(testCase == null)
            {
                throw new ArgumentNullException(testCase);
            }
            this.testSuite = testSuite;
            this.testCase = testCase;
        }
        // ...
    }
