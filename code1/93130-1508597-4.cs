    public static IEnumerable<TimeSpan> This(Action subject)
    {
        subject();     // warm up
        GC.Collect();  // compact Heap
        GC.WaitForPendingFinalizers(); // and wait for the finalizer queue to empty
        var watch = new Stopwatch();
        while (true)
        {
            watch.Reset();
            watch.Start();
            subject();
            watch.Stop();
            yield return watch.Elapsed;  // TimeSpan
        }
    }
