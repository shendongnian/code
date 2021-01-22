    private TestHarness<ITestRunner> testHarness;
    
    public TestHarness<ITestRunner> TestHarness
    {
        get
        {
            if (null == testHarness)
            {
                string sourcePath = Path.Combine(Application.StartupPath, "TestRunner.cs");
    
                testHarness = new TestHarness<ITestRunner>(sourcePath , typeof(TestRunner).FullName);
            }
    
            return testHarness;
        }
    }
    
    public ITestRunner TestHarnessInterface
    {
        get { return TestHarness.Interface; }
    }
    
