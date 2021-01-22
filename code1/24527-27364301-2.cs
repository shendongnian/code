    public static class DateTimeTolerance
    {
        private static TimeSpan _defaultTolerance = TimeSpan.FromMilliseconds(10); // 10ms default resolution
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
        // Additional overload that can deal with Nullable dates
        // (treats null as DateTime.MinValue)
        public static DateTimeWithin Within(this DateTime? dateTime)
        {
            return dateTime.GetValueOrDefault().Within();
        }
        public static DateTimeWithin Within(this DateTime? dateTime, TimeSpan tolerance)
        {
            return dateTime.GetValueOrDefault().Within(tolerance);
        }
    }
    public class DateTimeWithin
    {
        public DateTimeWithin(DateTime dateTime, TimeSpan tolerance)
        {
            DateTime = dateTime;
            Tolerance = tolerance;
        }
        public TimeSpan Tolerance { get; private set; }
        public DateTime DateTime { get; private set; }
        public static bool operator ==(DateTime lhs, DateTimeWithin rhs)
        {
            return (lhs - rhs.DateTime).Duration() <= rhs.Tolerance;
        }
        public static bool operator !=(DateTime lhs, DateTimeWithin rhs)
        {
            return (lhs - rhs.DateTime).Duration() > rhs.Tolerance;
        }
        public static bool operator ==(DateTimeWithin lhs, DateTime rhs)
        {
            return rhs == lhs;
        }
        public static bool operator !=(DateTimeWithin lhs, DateTime rhs)
        {
            return rhs != lhs;
        }
        // Overloads that can deal with Nullable dates
        public static bool operator !=(DateTimeWithin lhs, DateTime? rhs)
        {
            return rhs != lhs;
        }
        public static bool operator ==(DateTime? lhs, DateTimeWithin rhs)
        {
            if (!lhs.HasValue && rhs.DateTime == default(DateTime)) return true;
            if (!lhs.HasValue) return false;
            return (lhs.Value - rhs.DateTime).Duration() <= rhs.Tolerance;
        }
        public static bool operator !=(DateTime? lhs, DateTimeWithin rhs)
        {
            if (!lhs.HasValue && rhs.DateTime == default(DateTime)) return true;
            if (!lhs.HasValue) return false;
            return (lhs.Value - rhs.DateTime).Duration() > rhs.Tolerance;
        }
        public static bool operator ==(DateTimeWithin lhs, DateTime? rhs)
        {
            return rhs == lhs;
        }
    }
