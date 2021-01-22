    public sealed class TimerTask
    {
        private Timer _timer;
        private int _period;
        public TimerTask(int period)
        {
            _period = period;
            _timer = new Timer(new TimerCallback(Run), "Hello ....", Timeout.Infinite, period);
        }
        public void Start()
        {
            _timer.Change(0, _period);
        }
        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        private void Run(Object param)
        {
            Console.WriteLine(param.ToString());
        }
    }
