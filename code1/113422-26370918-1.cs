    public static DateTime AddYears(this DateTime datetime, int years)
    {
        return CultureInfo.InvariantCulture.Calendar.AddYears(datetime, years);
    }
    public static DateTime AddMonths(this DateTime datetime, int months)
    {
        return CultureInfo.InvariantCulture.Calendar.AddMonths(datetime, months);
    }
    DateTime yearsAgo = datetime.AddYears(-years);
    DateTime monthsInFuture = datetime.AddMonths(months);
