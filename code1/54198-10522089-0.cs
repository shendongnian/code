    public static class TimeSpanExtensions
    {
        public static string Verbose(this TimeSpan timeSpan)
        {
            return String.Format("{0} hours {1} minutes", timeSpan.Hours, timeSpan.Minutes);
        }
    }
