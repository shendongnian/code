    //prevent the JIT Compiler from optimizing Fkt calls away
    long seed = Environment.TickCount;
    //use the second Core/Processor for the test
    Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
    //prevent "Normal" Processes from interrupting Threads
    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
    //prevent "Normal" Threads from interrupting this thread
    Thread.CurrentThread.Priority = ThreadPriority.Highest;
    //warm up
    method();
    var stopwatch = new Stopwatch()
    for (int i = 0; i < repetitions; i++)
    {
        stopwatch.Reset();
        stopwatch.Start();
        for (int j = 0; j < iterations; j++)
            method();
        stopwatch.Stop();
        print stopwatch.Elapsed.TotalMilliseconds;
    }
