    public class TestServiceConsumer
    {
        private ITestService testService;    
    
        public TestServiceConsumer(IIndex<string, ITestService> testServices)
        {
            testService = testServices["service"];
        }
    }
