    public NSDate ConvertDateTimeToNSDate(DateTime date)
    {
        DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime(
            new DateTime(2001, 1, 1, 0, 0, 0) );
        return NSDate.FromTimeIntervalSinceReferenceDate(
            (date - newDate).TotalSeconds);
    }
    public DateTime ConvertNsDateToDateTime(NSDate date)
    {
        DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime( 
            new DateTime(2001, 1, 1, 0, 0, 0) );
        return newDate.AddSeconds(date.SecondsSinceReferenceDate);
    }
