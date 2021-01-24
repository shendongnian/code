    public class Scheduler : IScheduler
    {
        private static readonly IScheduler scheduler = CreateScheduler();
    
        private readonly Timer timer;
    
        public Scheduler()
        {
            refreshTimer = new Timer
            {
                Enabled = false,
                AutoReset = false
            };
        }
    
        public static IScheduler GetScheduler()
        {
            return scheduler;
        }
    
        public void StopTimer()
        {
            timer.Stop();
        }
        
        public virtual IScheduler CreateScheduler()
        {
             return new Scheduler();
        }
        // some other methods
    }
