    static void Profile(string description, int iterations, Action func) {
        
        // clean up
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        // warm up 
        func();
        var watch = new Stopwatch();
        watch.Start();
        for (int i = 0; i < iterations; i++) {
            func();
        }
        watch.Stop();
        Console.Write(description);
        Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
    }
