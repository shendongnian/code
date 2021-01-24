    public static List<DateTime> MapToDateTimes(this List<string> dateTimeStrings, string format = "M/d h:mm tt")
    {
        IEnumerable<DateTime> mapped = dateTimeStrings
            .Select(s => DateTime.ParseExact(s, format, CultureInfo.InvariantCulture));
        return mapped.ToList();
    }
    
