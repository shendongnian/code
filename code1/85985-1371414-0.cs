    public static bool IsRegexPatternValid(String pattern)
    {
        try
        {
            new Regex(pattern);
            return true;
        }
        catch { }
        return false;
    }
