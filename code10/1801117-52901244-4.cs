    public static string DebugInfo
    {
       get
       {
          ThreadPool.GetMaxThreads(out var maxThreads, out _);
          ThreadPool.GetAvailableThreads(out var threads, out _);
          var usedThreads = maxThreads - threads;
          var mt = $"{usedThreads.ToString().PadLeft(4)}/{maxThreads.ToString().PadLeft(4)}";
          return $"Threads {mt.PadRight(8)}";
       }
    }
    public static Task SleepAsyncA(int millisecondsTimeout)
    {
       return Task.Run(() => { Console.WriteLine("SleepAsyncA " + DebugInfo);  Thread.Sleep(millisecondsTimeout); });
    }
    
    public static Task SleepAsyncB(int millisecondsTimeout)
    {
       TaskCompletionSource<bool> tcs = null;
       var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
    
       Console.WriteLine("SleepAsyncB " + DebugInfo);
    
       tcs = new TaskCompletionSource<bool>(t);
       t.Change(millisecondsTimeout, -1);
    
       return tcs.Task;
    }
