    [TearDown]
     public void TearDown()
     {
       if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
       {
          //your code
       }
     }
