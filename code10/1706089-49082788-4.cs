    public static DateTime GetDateTime(Enums.DateTimePeriod period = Enums.DateTimePeriod.Week)
    {
        DateTime retVal = DateTime.Now;
        if (period == Enums.DateTimePeriod.Day)
        {
            retVal = retVal.AddDays(1);
        }
        else if (period == Enums.DateTimePeriod.Week)
        {
            retVal = retVal.AddDays(7);
        }
        return retVal;
    } 
