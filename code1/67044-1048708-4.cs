    static void Profile(string description, int iterations, Action func) {
        //Run at highest priority to minimize fluctuations caused by other processes/threads
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
        Thread.CurrentThread.Priority = ThreadPriority.Highest;
        // warm up 
        func();
        var watch = new Stopwatch(); 
 
        // clean up
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        watch.Start();
        for (int i = 0; i < iterations; i++) {
            func();
        }
        watch.Stop();
        Console.Write(description);
        Console.WriteLine(" Time Elapsed {0} ms", watch.Elapsed.TotalMilliseconds);
    }
