    public static T EvaluateAsync<T> (this Func<T> func, Timespan timeout)
    {
      var result = func.BeginInvoke(null, null);
      
      if (!result.AsyncWaitHandle.WaitOne(timeout))
           throw new TimeoutException ("Operation did not complete on time.");
    
      return func.EndInvoke(result);
    }
    
    static void Example()
    {
       var myMethod = new Func<int>(ExampleLongRunningMethod);
    
      // should return
      int result = myMethod.EvaluateAsync(TimeSpan.FromSeconds(2));
      
      // should throw
      int result2 = myMethod.EvaluateAsync(TimeSpan.FromMilliseconds(100));
    }
    
    static int ExampleLongRunningMethod()
    {
      Thread.Sleep(1000);
      return 42;
    }
