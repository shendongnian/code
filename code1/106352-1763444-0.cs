    public static DateTime TruncateToSecond(DateTime original)
    {
        return new DateTime(original.Year, original.Month, original.Day,
            original.Hour, original.Minute, original.Second);
    }
    ...
    if (TruncateToSecond(userTime) == TruncateToSecond(dbTime))
        ...
