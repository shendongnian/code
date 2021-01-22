    private static string DateToString(DateTime input)
    {
        return input.ToString("yyyy-MM-dd");
    }
    
    private static DateTime StringToDate(string input)
    {
        return DateTime.ParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
