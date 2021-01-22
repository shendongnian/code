    public static DateTime calcMondayDate(DateTime input)
    {
        int delta = (7 - (DayOfWeek.Monday - input.DayOfWeek)) % 7;
        return input.AddDays(-delta);
    }
