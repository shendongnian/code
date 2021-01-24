    public class DateSpan
    {
        public DateSpan(DateTime start, DateTime end, bool isBlocked = false)
        {
            StartDate = start;
            EndDate = end;
            IsBlocked = isBlocked;
        }
    
        public DateSpan(DateTime start, int duration, bool isBlocked = false)
        {
            StartDate = start;
            EndDate = start.AddHours(duration);
            IsBlocked = isBlocked;
        }
    
        public bool IsBlocked { get; set; }
    
    
        public static void Main(string[] args)
        {
            // available time spans
            var MyTimeSpans = new System.Collections.Generic.List<DateSpan>();
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 1, 5, 0, 0), 2));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 2, 4, 0, 0), 2));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 2, 5, 0, 0), 2));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 2, 1, 30, 0), 2));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 4, 5, 0, 0), 2));
    
            // blocked time spans
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 1, 10, 0, 0), 2, true));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 2, 5, 0, 0), 2, true));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 3, 5, 0, 0), 2, true));
            MyTimeSpans.Add(new DateSpan(new DateTime(2018, 9, 4, 4, 0, 0), 2, true));
    
            // you can use Linq or some other technique to separate this out as needed.
            var AvailableHours = MyTimeSpans.Where(ts => ts.IsBlocked == false).ToList();
            var BlockTimes = MyTimeSpans.Where(ts => ts.IsBlocked == true).ToList();
    
            // Do Additional Stuff
        }
    }
