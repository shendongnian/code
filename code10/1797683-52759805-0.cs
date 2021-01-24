     public class TimerService : ITimerService
    {
        private readonly System.Timers.Timer _timer;
        private  DateTime _startTime = DateTime.Now;
        private double _timerSettings;
        public TimerService()
        {
          _timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = 60000,
            };
            _timer.Elapsed += (sender, args) =>
            {
               //Backup Data method here
                _startTime = DateTime.Now;
            };
        }
        public double GetTimerInterval()
        {
            return _timer.Interval;
        }
        public void StopTimer()
        {
            if (_timer == null)
            {
                throw new ApplicationException("Timer not primed.");
            }
            _timer.Stop();
        }
        public void StartTimer()
        {
            if (_timer == null)
            {
                throw new ApplicationException("Timer not primed.");
            }
            _startTime = DateTime.Now;
            _timer.Start();
        }
    }
