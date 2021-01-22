    internal static DateTime Parse(string s, DateTimeFormatInfo dtfi, DateTimeStyles styles)
    {
        DateTimeResult result = new DateTimeResult();
        result.Init();
        if (!TryParse(s, dtfi, styles, ref result))
        {
            throw GetDateTimeParseException(ref result);
        }
        return result.parsedDate;
    }
