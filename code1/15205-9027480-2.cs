    public static DateTime GmtToPacific(DateTime dateTime)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(dateTime,
            TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
    }
