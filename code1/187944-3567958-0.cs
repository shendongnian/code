    public struct Time 
    {
        private readonly int _hour;
        private readonly int _minute;
        private readonly int _second;
        public Time(int hour, int minute, int second)
        {
            if (hour < 0 || hour >= 24)
                throw new ArgumentOutOfRangeException("hour", "Hours must be between 0 and 23 inclusive");
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException("minute", "Minutes must be between 0 and 23 inclusive");
            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException("second", "Seconds must be between 0 and 23 inclusive");
            _hour = hour;
            _minute = minute;
            _second = second;
        }
        public Time(Time time)
            : this(time.Hour, time.Minute, time.Second)
        {
            
        }
        public int Hour { get { return _hour; } }
        public int Minute { get { return _minute; } }
        public int Second { get { return _second; } }
        public override string ToString()
        {
            return ToString(true);
        }
        public string ToString(bool showSeconds)
        {
            if (showSeconds)
                return string.Format("{0:00}:{1:00}:{2:00}", Hour, Minute, Second);
            return string.Format("{0:00}:{1:00}:{2:00}", Hour, Minute);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (Time)) return false;
            return Equals((Time) obj);
        }
        public bool Equals(Time other)
        {
            return other._hour == _hour && other._minute == _minute && other._second == _second;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = _hour;
                result = (result*397) ^ _minute;
                result = (result*397) ^ _second;
                return result;
            }
        }
    }
    public class OpeningHours
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Time OpeningTime { get; set; }
        public Time ClosingTime { get; set; }
        public OpeningHours(DayOfWeek dayOfWeek, Time openingTime, Time closingTime)
        {
            DayOfWeek = dayOfWeek;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }
    }
