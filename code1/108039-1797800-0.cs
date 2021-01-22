    public abstract class TimeMachine
    {
        public abstract DateTime GetCurrentDateTime();
        public DateTime GetCurrentDate(){ return GetCurrentDateTime().Date; };
        public TimeSpan GetCurrentTime(){ return GetCurrentDateTime().TimeOfDay; };
    }
