    public static bool TryParseBoolean(this string value, out bool result)
    {
        // For a case-insensitive compare, I recommend using
        // "yes".Equals(value, StringComparison.OrdinalIgnoreCase); 
        if (value == "yes")
        {
            result = true;
            return true;
        }
        if (value == "no")
        {
            result = false;
            return true;
        }
        return bool.TryParse(value, out result);
    }
