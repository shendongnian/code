    private static bool IsValidRegex(string pattern)
    {
        if (pattern.IsNullOrEmpty()) return false;
    
        try
        {
            Regex.Match("", pattern);
        }
        catch (ArgumentException)
        {
            return false;
        }
    
        return true;
    }
