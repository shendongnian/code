    [Serializable()]
    public class OpeningTime
    {
        protected OpeningTime()
        {
        }
    
        public OpeningTime(DayOfWeek dayOfWeek, TimeSpan fromTime, TimeSpan toTime) 
            : this(dayOfWeek, fromTime.Hours, fromTime.Minutes, toTime.Hours, toTime.Minutes) { }
    
        public OpeningTime(DayOfWeek dayOfWeek, int fromHours, int fromMinutes, int toHours, int toMinutes)
        {
            if (fromHours < 0 || fromHours > 23)
            {
                throw new ArgumentOutOfRangeException("fromHours", "fromHours must be in the range 0 to 23 inclusive");
            }
    
            if (toHours < 0 || toHours > 23)
            {
                throw new ArgumentOutOfRangeException("toHours", "toHours must be in the range 0 to 23 inclusive");
            }
    
            if (fromMinutes < 0 || fromMinutes > 59)
            {
                throw new ArgumentOutOfRangeException("fromMinutes", "fromMinutes must be in the range 0 to 59 inclusive");
            }
    
            if (toMinutes < 0 || toMinutes > 59)
            {
                throw new ArgumentOutOfRangeException("toMinutes", "toMinutes must be in the range 0 to 59 inclusive");
            }
    
            this.FromTime = new TimeSpan(fromHours, fromMinutes, 0);
            this.ToTime = new TimeSpan(toHours, toMinutes, 0);
    
            if (this.FromTime >= this.ToTime)
            {
                throw new ArgumentException("From Time must be before To Time");
            }
    
            this.DayOfWeek = dayOfWeek;
        }
    
        public virtual DayOfWeek DayOfWeek { get; private set; }
    
        public virtual TimeSpan FromTime { get; private set; }
    
        public virtual TimeSpan ToTime { get; private set; }
    }
