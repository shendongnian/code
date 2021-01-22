    public static bool IsFuture(this DateTime date, DateTime from)
    {
        return date.Date > from.Date;
    }
    
    public static bool IsFuture(this DateTime date)
    {
        return date.IsFuture(DateTime.Now);
    }
    
    public static bool IsPast(this DateTime date, DateTime from)
    {
        return date.Date < from.Date;
    }
    
    public static bool IsPast(this DateTime date)
    {
        return date.IsPast(DateTime.Now);
    }
