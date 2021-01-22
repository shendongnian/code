    public class PreciseDatetime
    {
        // using DateTime.Now resulted in many many events with the same timestamp.
        // use static variables in case there are many instances off this class in use in the same program
        // (that way they will all be in sync)
        private static readonly Stopwatch myStopwatch = new Stopwatch();
        private static System.DateTime myStopwatchStartTime;
        static PreciseDatetime()
        {
            Reset();
            try
            {
                // In case the system clock gets updated
                SystemEvents.TimeChanged += SystemEvents_TimeChanged;
            }
            catch (Exception)
            {                
            }
        }
        static void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            Reset();
        }
        // SystemEvents.TimeChanged can be slow to fire (3 secs), so allow forcing of reset
        static public void Reset()
        {
            myStopwatchStartTime = System.DateTime.Now;
            myStopwatch.Restart();
        }
        public System.DateTime Now { get { return myStopwatchStartTime.Add(myStopwatch.Elapsed); } }
    }
