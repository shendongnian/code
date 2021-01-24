    public static class DateTimeExtensions
    {
        public static DateTime SubtractDays(this DateTime start, int days)
        {
            return start.AddDays(-days);
        }
    }
