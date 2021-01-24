    public class MyService : ServiceBase
    {
        private readonly TimeSpan TimerInterval = TimeSpan.FromSeconds(5); // 'x' seconds here
        private Timer _timer; // System.Threading.Timer
        protected override void OnStart(string[] args)
        {
            _timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimerInterval);
        }
        private void TimerCallback(object state)
        {
            // do whatever you want here,
            // process your requests etc.
            // this method will fire every x seconds while service is running
        }
  
        protected override void OnStop()
        {
            _timer.Dispose();
        }
    }
