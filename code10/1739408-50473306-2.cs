    private static DateTime GetDate(string input)
    {
        DateTime result;
        DateTime.TryParseExact(input, "yyyyMMdd", CultureInfo.CurrentCulture, 
            DateTimeStyles.None, out result);
        return result;
    }
