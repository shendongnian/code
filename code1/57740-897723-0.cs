    public static bool EqualsAny(
        this string s, 
        StringComparison comparisonType, 
        params string[] tokens)
    {
        foreach (string token in tokens)
        {
            if (s.Equals(token, comparisonType))
            {
                return true;
            }
        }
        return false;
    }
