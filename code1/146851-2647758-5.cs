    public struct TimeZoneTime
    {
       public TimeZoneInfo TimeZone;
       public DateTimeOffset Time;
    
       public TimeZoneTime(DateTimeOffset time)
       {
          this.TimeZone = TimeZone.Local;
          this.Time = time;   
       }
       public TimeZoneTime(TimeZoneInfo tz, DateTimeOffset time)
       {
          if (tz == null) 
             throw new ArgumentNullException("The time zone cannot be a null reference.");
    
          this.TimeZone = tz;
          this.Time = time;   
       }
    
       public TimeZoneTime AddTime(TimeSpan interval)
       {
          // Convert time to UTC
          DateTimeOffset utcTime = TimeZoneInfo.ConvertTime(this.Time, TimeZoneInfo.Utc);      
          // Add time interval to time
          utcTime = utcTime.Add(interval);
          // Convert time back to time in time zone
          return new TimeZoneTime(this.TimeZone, TimeZoneInfo.ConvertTime(utcTime, this.TimeZone));
       }
        public DateTime LocalDate 
        {
            get { return Time.ToOffset(TimeZone); }
        }
    }
