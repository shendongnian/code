    public static class TimeSpanExtensions
    {
        public static string ToString(this TimeSpan time, string format)
        {
            DateTime dateTime = DateTime.Today.Add(time);
            return dateTime.ToString(format);
        }
    }
