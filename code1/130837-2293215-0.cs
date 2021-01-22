    public static DateTime RoundDown(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, 
             dateTime.Day, dateTime.Hour, (dateTime.Minute / 15) * 15, 0);
    }
