    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
        {
            PerformCleanUpFromTest();
        }
    }
