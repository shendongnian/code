    public static class DateTimeExtensions
    {
        public static long currentTimeMillis(this DateTime d)
        {
            Dim Jan1st1970 As new DateTime((1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long) ((DateTime.UtcNow - Jan1st1970).TotalMilliseconds);
        }
    }
