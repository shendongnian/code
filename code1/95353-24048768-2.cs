    private readonly Mutex testMutex = new Mutex(true, "MySpecificTestScenarioUniqueMutexString");
    
    [TestInitialize]
    public void Initialize()
    {
    	testMutex.WaitOne(TimeSpan.FromSeconds(1));
    }
    
    [TestCleanup]
    public void Cleanup() {
    	testMutex.ReleaseMutex();
    }
