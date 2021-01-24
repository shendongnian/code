    protected void ExecuteTest(Action test)
    {
      try
      {
        test();
      }
      catch (Exception ex)
      {
        //If the caught exception is not an assert exception but an unhandled exception.
        if (!(ex is AssertionException))
          Assert.Fail(ex.Message);
      }
    }
