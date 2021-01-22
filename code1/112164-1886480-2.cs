    private static DateTime? ParseDate(string input)
    {
        DateTime result;
        if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
        {
            return result;
        }
        return null;
    }
