    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Sample
    {
        /// <summary>
        /// Use to run a cron job on a timer
        /// </summary>
        public class CronJob
        {
            private VoidHandler cronJobDelegate;
            private DateTime? start;
            private TimeSpan startTimeSpan;
            private TimeSpan Interval { get; set; }
    
            private Timer timer;
    
            /// <summary>
            /// Constructor for a cron job
            /// </summary>
            /// <param name="cronJobDelegate">The delegate that will perform the task</param>
            /// <param name="start">When the cron job will start. If null, defaults to now</param>
            /// <param name="interval">How long between each execution of the task</param>
            public CronJob(VoidHandler cronJobDelegate, DateTime? start, TimeSpan interval)
            {
                if (cronJobDelegate == null)
                {
                    throw new ArgumentNullException("Cron job delegate cannot be null");
                }
    
                this.cronJobDelegate = cronJobDelegate;
                this.Interval = interval;
    
                this.start = start;
                this.startTimeSpan = DateTime.Now.Subtract(this.start ?? DateTime.Now);
    
                this.timer = new Timer(TimerElapsed, this, Timeout.Infinite, Timeout.Infinite);
            }
    
            /// <summary>
            /// Start the cron job
            /// </summary>
            public void Start()
            {
                this.timer.Change(this.startTimeSpan, this.Interval);
            }
    
            /// <summary>
            /// Stop the cron job
            /// </summary>
            public void Stop()
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
    
            protected static void TimerElapsed(object state)
            {
                CronJob cronJob = (CronJob) state;
                cronJob.cronJobDelegate.Invoke();
            }
        }
    }
