    // Create new stopwatch
    Stopwatch stopwatch = new Stopwatch();
    
    // Begin timing
    stopwatch.Start();
    
    // Do something
    for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(1);
    }
    
    // Stop timing
    stopwatch.Stop();
    
    // Write result
    Console.WriteLine("Time elapsed (ms): {0}", stopwatch.Elapsed.TotalMilliseconds);
    Console.WriteLine("Time elapsed (s): {0}", stopwatch.Elapsed.TotalSeconds);
