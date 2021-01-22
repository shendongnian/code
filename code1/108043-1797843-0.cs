    public class TimeMachine
    {
        public virtual DateTime GetCurrentDateTime(){ return DateTime.Now; };
        public DateTime GetCurrentDate(){ return GetCurrentDateTime().Date; };
        public TimeSpan GetCurrentTime(){ return GetCurrentDateTime().TimeOfDay; };
    }
