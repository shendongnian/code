    public class TimerTask
    {
        private readonly Timer _taskTimer;
        public TimerTask(Action action, int interval = 10000)
        {
            _taskTimer = new Timer { AutoReset = true, Interval = interval };
            _taskTimer.Elapsed += (_, __) => action();
        }
        public void Start() { _taskTimer.Start(); }
        public void Stop() { _taskTimer.Stop(); }
    }
