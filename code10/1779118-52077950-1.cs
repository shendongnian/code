    public static DateTime? TryParseDateTime(string source)
    {
        if (DateTime.TryParse(source, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var parsedDate))
        {
            return parsedDate.ToUniversalTime(); // .Date;
        }
        return null;
    }
