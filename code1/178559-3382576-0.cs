    class Food
    {
        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
        public TimeSpan CookingTime
        {
            get { return _stopwatch.Elapsed; }
        }
    }
