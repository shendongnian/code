    public class TestData
    {
        public TestData(ITestDataRepository repository)
        {
            Repository = repository;
        }
    
        public ITestDataRepository Repository { get; private set; }
    
        public string SomeData { get; set; }
    
        public void Add()
        {
            if (Repository != null)
            {
                Repository.Add(this);
            }
        }
    }
