    // cached somewhere
    var perf2 = new PerformanceCounter("Cat", "CallTime", "Instance", false);
    
    [ThreadStatic]
    Stopwatch sw;
    
    // where ever you are setting init_call_time
    if (sw == null)
        sw = new Stopwatch();
    sw.Start();
    // then when the task has finished
    sw.Stop();
    perf2.IncrementBy(sw.ElapsedMilliseconds); // or tick, whatever you want to use
    sw.Reset();
