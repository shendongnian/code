    static void ProfileGarbage(string description, int iterations, Action func) {
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
    
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        watch.Stop();
        Console.Write(description);
        Console.WriteLine(" Time Elapsed {0} ms", watch.Elapsed.TotalMilliseconds);
    }
