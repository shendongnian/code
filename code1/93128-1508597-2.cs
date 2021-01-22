    public IEnumerator<TimeSpan> GetEnumerator()
    {
        subject();     // warm up
        GC.Collect();  // compact Heap
        GC.WaitForPendingFinalizers(); // and wait for the finalizer que to empty
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
