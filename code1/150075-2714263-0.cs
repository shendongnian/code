    public static class TimeSpanUtility
    {
       public static TimeSpan Round( this TimeSpan ts )
       {
           var sign = ts < TimeSpan.Zero ? -1 : 1;
           var roundBy = ts.Minutes > 30 ? 1 : 0;
           return new TimeSpan.FromHours( ts.TotalHours + (sign * roundBy) );
       }
    }
    // usage would be:
    var someTimeSpan = new TimeSpan( 2, 45, 15 );
    var roundedTime = someTimeSpan.Round();
