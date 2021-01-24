    public static class BackgroundJob
    {
       public static async Task RunAsync(CancellationToken token)
       {
          ... your code
    
          await Task.Delay(TimeSpan.FromMinutes(5), token);
       }
    }
