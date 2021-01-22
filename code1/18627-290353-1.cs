    public static class DateTimeExtensions
    {
        private DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long currentTimeMillis(this DateTime d)
        {
            return (long) ((DateTime.UtcNow - Jan1st1970).TotalMilliseconds);
        }
    }
