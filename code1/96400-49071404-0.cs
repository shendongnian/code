    public static async Task<T> Do<T>(Task<T> task, TimeSpan retryInterval, int maxAttemptCount = 3)
    {
      var exceptions = new List<Exception>();
      for (int attempted = 0; attempted < maxAttemptCount; attempted++)
      {
        try
        {
          if (attempted > 0)
          {
            await Task.Delay(retryInterval);
          }
            return await task;
          }
        catch (Exception ex)
        {
          exceptions.Add(ex);
        }
      }
      throw new AggregateException(exceptions);
    }
