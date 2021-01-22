    public static class FuzzyDateExtensions
    {
        public static string ToFuzzyDateString(this TimeSpan timespan)
        {
            return timespan.ToFuzzyDateString(new Grammar());
        }
        public static string ToFuzzyDateString(this TimeSpan timespan,
            Grammar grammar)
        {
            return GetFuzzyDateString(timespan, grammar);
        }
        public static string ToFuzzyDateString(this DateTime datetime)
        {
            return (DateTime.Now - datetime).ToFuzzyDateString();
        }
        public static string ToFuzzyDateString(this DateTime datetime,
           Grammar grammar)
        {
            return (DateTime.Now - datetime).ToFuzzyDateString(grammar);
        }
        private static string GetFuzzyDateString(TimeSpan timespan,
           Grammar grammar)
        {
            timespan = timespan.Duration();
            if (timespan >= grammar.AgesAgoThreshold)
            {
                return grammar.AgesAgo;
            }
            if (timespan < new TimeSpan(0, 2, 0))    // 2 minutes
            {
                return grammar.JustNow;
            }
            if (timespan < new TimeSpan(1, 0, 0))    // 1 hour
            {
                return String.Format(grammar.MinutesAgo, timespan.Minutes);
            }
            if (timespan < new TimeSpan(1, 55, 0))    // 1 hour 55 minutes
            {
                return grammar.OneHourAgo;
            }
            if (timespan < new TimeSpan(12, 0, 0)    // 12 hours
                && (DateTime.Now - timespan).IsToday())
            {
                return String.Format(grammar.HoursAgo, timespan.RoundedHours());
            }
            if ((DateTime.Now.AddDays(1) - timespan).IsToday())
            {
                return grammar.Yesterday;
            }
            if (timespan < new TimeSpan(32, 0, 0, 0)    // 32 days
                && (DateTime.Now - timespan).IsThisMonth())
            {
                return String.Format(grammar.DaysAgo, timespan.RoundedDays());
            }
            if ((DateTime.Now.AddMonths(1) - timespan).IsThisMonth())
            {
                return grammar.LastMonth;
            }
            if (timespan < new TimeSpan(365, 0, 0, 0, 0)    // 365 days
                && (DateTime.Now - timespan).IsThisYear())
            {
                return String.Format(grammar.MonthsAgo, timespan.RoundedMonths());
            }
            if ((DateTime.Now - timespan).AddYears(1).IsThisYear())
            {
                return grammar.LastYear;
            }
            return String.Format(grammar.YearsAgo, timespan.RoundedYears());
        }
    }
