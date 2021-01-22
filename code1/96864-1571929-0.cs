    TimeSpan startingTime, duration;
    GC.Collect();
    GC.WaitForPendingFinalizers();
    startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
    DoLengthyWork();
    duration = Process.GetCurrentProcess.Threads(0).UserProcessorTime.Subtract(startingTime);
