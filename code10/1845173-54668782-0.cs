    public class LiveCalculator
    {
        private readonly Timer _timer;
        private List<int> _allValues
        private int _lastSum;
        public int LastSum => _lastSum;
        public LiveCalculator()
        {
            _allValues = new List<int>();
            _timer = new Timer { Interval = 1000 };
            _timer.Elapsed += _timer_Elapsed;
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _allValues.Add(42);
        }
        public void start()
        {
            _timer.Start();            
        }
        public void stop()
        {
            _timer.Stop();
            _lastResult = _allValues.Sum();
        }
    }
