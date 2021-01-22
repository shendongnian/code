    class Time
    {
        public int Hours   { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
    
        public Time(uint h, uint m, uint s)
        {
            if(h > 23 || m > 59 || s > 59)
            {
                throw new ArgumentException("Invalid time specified");
            }
            Hours = (int)h; Minutes = (int)m; Seconds = (int)s;
        }
        public Time(DateTime dt)
        {
            Hours = dt.Hour;
            Minutes = dt.Minute;
            Seconds = dt.Second;
        }
    
        public override string ToString()
        {  
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
    }
