    Private ReadOnly Mutex testMutex = New Mutex(true, "MySpecificTestScenarioUniqueMutexString");
    
    [TestInitialize]
    Public void Initialize()
    {
    	testMutex.WaitOne(TimeSpan.FromSeconds(1));
    }
    
    [TestCleanup]
    Public void Cleanup() {
    	testMutex.ReleaseMutex();
    }
