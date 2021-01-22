    Private ReadOnly Mutex testMutex = New Mutex(true, "MySpecificTestScenarioUniqueMutexString");
    
    [TestInitialize]
    Public void Initialize()
    {
    	FileTestMutex.WaitOne(TimeSpan.FromSeconds(1));
    }
    
    [TestCleanup]
    Public void Cleanup() {
    	FileTestMutex.ReleaseMutex();
    }
