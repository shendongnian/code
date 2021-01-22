    public class MyService : ServiceBase
    {
        private Timer workTimer;    // System.Threading.Timer
        protected override void OnStart(string[] args)
        {
            workTimer = new Timer(new TimerCallback(DoWork), null, 5000, 5000);
            base.OnStart(args);
        }
        protected override void OnStop()
        {
            workTimer.Dispose();
            base.OnStop();
        }
        private void DoWork(object state)
        {
            RunScheduledTasks();  // Do some work
        }
    }
