    public static bool IsStringOnlyWhitespace(this string str)
    {
        // if you want to check for null:
        return str == null || string.IsNullOrEmpty(string.Trim());
        // else
        return string.IsNullOrEmpty(string.Trim());
    }
