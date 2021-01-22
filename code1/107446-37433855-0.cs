        public static class UptimeMonitor
    {
        static DateTime StartTime { get; set; }
        static UptimeMonitor()
        {
            StartTime = DateTime.Now;
        }
        public static int UpTimeSeconds
        {
            get { return (int)Math.Round((DateTime.Now - StartTime).TotalSeconds,0); }
        }
    }
