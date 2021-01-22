    public class Entry {
    
       public DateTime StartPoint { get; set; }
       public TimeSpan Duration { get; set; }
    
       public DateTime StartDate { get { return StartPoint.Date; } }
       public TimeSpan StartTime { get { return StartPoint.TimeOfDay; } }
       public DateTime EndPoint { get { return StartPoint + Duration; } }
       public DateTime EndDate { get { return EndPoint.Date; } }
       public TimeSpan EndTime { get { return EndPoint.TimeOfDay; } }
    
    }
