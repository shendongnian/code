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
            return (lhs - rhs.DateTime).Duration() < rhs.Tolerance;
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
    }
