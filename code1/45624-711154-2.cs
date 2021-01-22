    public struct DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    
        public static DateRange ThisYear(DateTime date)
        {
            DateRange range = new DateRange();
        
            range.Start = new DateTime(date.Year, 1, 1);
            range.End = range.Start.AddYears(1).AddSeconds(-1);
        
            return range;
        }
        
        public static DateRange LastYear(DateTime date)
        {
            DateRange range = new DateRange();
        
            range.Start = new DateTime(date.Year - 1, 1, 1);
            range.End = range.Start.AddYears(1).AddSeconds(-1);
        
            return range;
        }
        
        public static DateRange ThisMonth(DateTime date)
        {
            DateRange range = new DateRange();
        
            range.Start = new DateTime(date.Year, date.Month, 1);
            range.End = range.Start.AddMonths(1).AddSeconds(-1);
        
            return range;
        }
        
        public static DateRange LastMonth(DateTime date)
        {
            DateRange range = new DateRange();
            
            range.Start = (new DateTime(date.Year, date.Month, 1)).AddMonths(-1);
            range.End = range.Start.AddMonths(1).AddSeconds(-1);
        
            return range;
        }
        
        public static DateRange ThisWeek(DateTime date)
        {
            DateRange range = new DateRange();
        
            range.Start = date.Date.AddDays(-(int)date.DayOfWeek);
            range.End = range.Start.AddDays(7).AddSeconds(-1);
        
            return range;
        }
        
        public static DateRange LastWeek(DateTime date)
        {
            DateRange range = ThisWeek(date);
        
            range.Start = range.Start.AddDays(-7);
            range.End = range.End.AddDays(-7);
        
            return range;
        }
    
