    [TearDown]
    public void TestTearDown()
    {
      // inc. class name
      var fullNameOfTheMethod = NUnit.Framework.TestContext.CurrentContext.Test.FullName; 
      // method name only
      var methodName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
      // the state of the test execution
      var state = NUnit.Framework.TestContext.CurrentContext.Result.State; // TestState enum
    }
