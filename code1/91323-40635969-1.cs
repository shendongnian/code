    [TearDown]
     public void TearDown()
     {
       if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
       {
          //your code
       }
     }
