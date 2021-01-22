    /// <summary>
    /// Alarm Class
    /// </summary>
    public class Alarm
    {
        private TimeSpan wakeupTime;
        public Alarm(TimeSpan WakeUpTime)
        {
            this.wakeupTime = WakeUpTime;
            System.Threading.Thread t = new System.Threading.Thread(TimerThread) { IsBackground = true, Name = "Alarm" };
            t.Start();
        }
        /// <summary>
        /// Alarm Event
        /// </summary>
        public event EventHandler AlarmEvent = delegate { };
        private void TimerThread()
        {
            DateTime nextWakeUp = DateTime.Today + wakeupTime;
            if (nextWakeUp < DateTime.Now) nextWakeUp = nextWakeUp.AddDays(1.0);
            while (true)
            {
                TimeSpan ts = nextWakeUp.Subtract(DateTime.Now);
                System.Threading.Thread.Sleep((int)ts.TotalMilliseconds);
                try { AlarmEvent(this, EventArgs.Empty); }
                catch { }
                nextWakeUp = nextWakeUp.AddDays(1.0);
            }
        }
    }
