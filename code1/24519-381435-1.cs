    public static class DateTimeTolerance
    {
        private static TimeSpan _defaultTolerance = TimeSpan.FromSeconds(10);
        public static void SetDefault(TimeSpan tolerance)
        {
            _defaultTolerance = tolerance;
        }
        public static DateTimeWithin Within(this DateTime dateTime, TimeSpan tolerance)
        {
            return new DateTimeWithin(dateTime, tolerance);
        }
        public static DateTimeWithin Within(this DateTime dateTime)
        {
            return new DateTimeWithin(dateTime, _defaultTolerance);
        }
    }
