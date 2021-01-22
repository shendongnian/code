    [TestCleanup]
    public void MyTestCleanup()
    {
        // Adding the following two lines of code fixed the issue
        GC.Collect();
        GC.WaitForPendingFinalizers();
        // Removes 'MyDatabase.db' from the testing directory.
        File.Delete(Path.Combine(this.TestContext.TestDeploymentDir, "MyDatabase.db"));
    }
