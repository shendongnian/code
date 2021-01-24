    public class TestServiceConsumer
    {
        private ITestService testService;    
    
        public TestServiceConsumer([KeyFilter("service")] ITestService testService)
        {
            this.testService = testService;
        }
    }
