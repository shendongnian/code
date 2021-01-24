    public static IEnumerable<DateTime> GetDateTimesOnly(IEnumerable<Enums.Day> days)
    {
        foreach (var day in days)
            yield return GetDateTime(day);
    }
