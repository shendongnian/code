    public class Entry{
       private DateTime _startPoint;
    
       public bool HasStartDate { get; private set; }
       public bool HasStartTime { get; private set; }
       public TimeSpan Duration { get; private set; }
       private void EnsureStartDate() {
          if (!HasStartDate) throw new ApplicationException("Start date is null.");
       }
       private void EnsureStartTime() {
          if (!HasStartTime) throw new ApplicationException("Start time is null.");
       }
       public DateTime StartPoint { get {
          EnsureStartDate();
          EnsureStartTime();
          return _startPoint;
       } }
    
       public DateTime StartDate { get {
          EnsureStartDate();
          return _startPoint.Date;
       } }
       public TimeSpan StartTime { get {
          EnsureStartTime();
          return _startPoint.TimeOfDay;
       } }
       public DateTime EndPoint { get { return StartPoint + Duration; } }
       public DateTime EndDate { get { return EndPoint.Date; } }
       public TimeSpan EndTime { get { return EndPoint.TimeOfDay; } }
       public Entry(DateTime startPoint, TimeSpan duration)
         : this (startPoint, true, true, duration) {}
       public Entry(TimeSpan duration)
         : this(DateTime.MinValue, false, false, duration) {}
       public Entry(DateTime startPoint, bool hasStartDate, bool hasStartTime, TimeSpan duration) {
          _startPoint = startPoint;
          HasStartDate = hasStartDate;
          HasStartTime = hasStartTime;
          Duration = duration;
       }
    
    }
