    private const string DateTimeFormatCharacters = "yYmMdDhHsS";
    private static bool IsDateTimeFormatString(string input)
    {
        foreach (char c in input)
            if (DateTimeFormatCharacters.IndexOf(c) < 0)
                return false;
        return true;
    }
