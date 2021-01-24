    public static DateTime RoundDate(DateTime input) 
    {
        var hour = input.Minutes > 30 ? input.Hour + 1 : input.Hour; //Rounding to get the nearest hour
        return new DateTime(input.Year, input.Month, input.Day, hour, 0);
    }
