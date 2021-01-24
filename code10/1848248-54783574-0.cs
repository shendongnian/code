    private static DateTime ParseDate(string input)
    {
        try
        {
            return DateTime.Parse(input, MyCultureInfo).Date;
        }
        catch (FormatException e)
        {
            throw new FormatException($"Unable to parse DateTime '{input}': {e.Message}", e);
        }
    }
