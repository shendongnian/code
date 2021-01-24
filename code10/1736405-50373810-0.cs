    void Main()
    {
        BenchmarkSwitcher.FromAssembly(GetType().Assembly).RunAll();
    }
    
    public class Benchmarks
    {
        private DateTime _Last = DateTime.Now;
        private DateTime _Next = DateTime.Now.AddSeconds(1);
        private Stopwatch _Stopwatch = Stopwatch.StartNew();
        
        [Benchmark]
        public void ReadDateTime()
        {
            bool areWeThereYet = DateTime.Now >= _Last.AddSeconds(1);
        }
    
        [Benchmark]
        public void ReadDateTimeAhead()
        {
            bool areWeThereYet = DateTime.Now >= _Next;
        }
    
        [Benchmark]
        public void ReadStopwatch()
        {
            bool areWeThereYet = _Stopwatch.ElapsedMilliseconds >= 1000;
        }
    }
