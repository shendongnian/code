    [TestInitialize]
    public void MyTestInitialize()
    {
        // Copies the embedded resource 'MyDatabase.db' to the Testing Directory
        CommonTestFixture.UnpackFile("MyDatabase.db", this.GetType(), this.TestContext.TestDeploymentDir);
    }
