    private long CombinedMs;
    
    ...
    
    private async static void DoSomethingAsync (int i)
    {
    
       var sw = new StopWatch();
       sw.Start();
       ...
       sw.Stop();
    
       Interlocked.Add(ref CombinedMs,sw.ElapsedMillisecond);
    
    }
    
