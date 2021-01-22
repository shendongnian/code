    try
    {
      repository.AddMessages(someMessages);
    }
    catch (Exception ex)
    {
      bool rethrow = ExceptionPolicy
        .HandleException(ex, "Global Policy");
      if (rethrow)
      {
        throw;
      }
    }
