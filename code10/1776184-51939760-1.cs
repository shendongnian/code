    [TestMethod]
    public void TestSomethingOnS1
    {
      testSomething(TestContext.Properties["server1"].ToString());
    }
    [TestMethod]
    public void TestSomethingOnS2
    {
      testSomething(TestContext.Properties["server2"].ToString());
    }
