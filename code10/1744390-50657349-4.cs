    public static class MyPolices
    {
        // Retry, waiting a specified duration between each retry
        public static Policy RetryPolicy = Policy
           .Handle<Exception>() // can be more specific like SqlException
           .WaitAndRetry(new[]
           {
              TimeSpan.FromSeconds(1),
              TimeSpan.FromSeconds(2),
              TimeSpan.FromSeconds(3)
           });
    }
