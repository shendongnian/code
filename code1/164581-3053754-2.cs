    public static class DayChangedNotifier
    {
        private static Timer timer;
        static DayChangedNotifier()
        {
            timer = new Timer(GetSleepTime());
            timer.Elapsed += (o, e) =>
                {
                    OnDayChanged(DateTime.Now.DayOfWeek);
                    timer.Interval = this.GetSleepTime();
                };
            timer.Start();
            SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);
        }
        private static void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            timer.Interval = GetSleepTime();
        }
        private static double GetSleepTime()
        {
            var midnightTonight = DateTime.Today.AddDays(1);
            var differenceInMilliseconds = (midnightTonight - DateTime.Now).TotalMilliseconds;
            return differenceInMilliseconds;
        }
        private static void OnDayChanged(DayOfWeek day)
        {
            var handler = DayChanged;
            if (handler != null)
            {
                handler(null, new DayChangedEventArgs(day));
            }
        }
        public static event EventHandler<DayChangedEventArgs> DayChanged;
    }
