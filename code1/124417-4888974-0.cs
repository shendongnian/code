    public static DateTime NSDateToDateTime(MonoTouch.Foundation.NSDate date)
    {
        return (new DateTime(2001,1,1,0,0,0)).AddSeconds(date.SecondsSinceReferenceDate);
    }
    
    public static MonoTouch.Foundation.NSDate DateTimeToNSDate(DateTime date)
    {
        return MonoTouch.Foundation.NSDate.FromTimeIntervalSinceReferenceDate((date-(new DateTime(2001,1,1,0,0,0))).TotalSeconds);
    }
