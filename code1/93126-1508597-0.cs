    public IEnumerator<long> GetEnumerator()
    {
        subject();     // warm up
        GC.Collect();  // compact Heap
        var watch = new Stopwatch();
        while (true)
        {
            watch.Reset();
            watch.Start();
            subject();
            watch.Stop();
            yield return watch.ElapsedMilliseconds;  // not ticks
        }
    }
