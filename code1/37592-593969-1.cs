    public class TimeOfDay
    {
        public int _minutesSinceMidnight = 0;
        public int Hour
        {
            get { return _minutesSinceMidnight / 60; }
            set { _minutesSinceMidnight = value * 60 + Minutes; }
        }
        public int Minute
        {
            get { return _minutesSinceMidnight % 60; }
            set { _minutesSinceMidnight = Hour * 60 + value; }
        }
        public TimeOfDay(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
    }
