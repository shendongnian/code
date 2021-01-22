    public static DateTime StartOfWeek ( this DateTime dt, DayOfWeek? firstDayOfWeek )
    {
        DayOfWeek fdow;
        if ( firstDayOfWeek.HasValue  )
        {
            fdow = firstDayOfWeek.Value;
        }
        else
        {
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            fdow = ci.DateTimeFormat.FirstDayOfWeek;
        }
        int diff = dt.DayOfWeek - fdow;
        if ( diff < 0 )
        {
            diff += 7;
        }
        return dt.AddDays( -1 * diff ).Date;
    }
