    public static class TimeoutOperation
    {
      private static readonly TimeSpan DefaultTimeout = new TimeSpan(0, 0, 10);
      private static readonly TimeSpan DefaultGranularity = new TimeSpan(0, 0, 0, 0, 100);
    
      public static ThreadResult<TResult> DoWithTimeout<TResult>(Func<TResult> action)
      {
        return DoWithTimeout<TResult>(action, DefaultTimeout);
      }
    
      public static ThreadResult<TResult> DoWithTimeout<TResult>(Func<TResult> action, TimeSpan timeout)
      {
        return DoWithTimeout<TResult>(action, timeout, DefaultGranularity);
      }
    
      public static ThreadResult<TResult> DoWithTimeout<TResult>(Func<TResult> action, TimeSpan timeout, TimeSpan granularity)
      {
        Thread thread = BuildThread<TResult>(action);
        Stopwatch stopwatch = Stopwatch.StartNew();
        ThreadResult<TResult> result = new ThreadResult<TResult>();
    
        thread.Start(result);
        do
        {
          if (thread.Join(granularity) && !result.WasSuccessful)
          {
            thread = BuildThread<TResult>(action);
            thread.Start(result);
          }
    
        } while (stopwatch.Elapsed < timeout && !result.WasSuccessful);
        stopwatch.Stop();
    
        if (thread.ThreadState == System.Threading.ThreadState.Running)
          thread.Abort();
    
        return result;
      }
    
      private static Thread BuildThread<TResult>(Func<TResult> action)
      {
        return new Thread(p =>
        {
          ThreadResult<TResult> r = p as ThreadResult<TResult>;
          try { r.Result = action(); r.WasSuccessful = true; }
          catch (Exception) { r.WasSuccessful = false; }
        });
      }
    
      public class ThreadResult<TResult>
      {
        public TResult Result { get; set; }
        public bool WasSuccessful { get; set; }
      }
    }
