    public delegate void Proc();
    public static class With
    {
        public static Int64 Benchmark(Proc action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
