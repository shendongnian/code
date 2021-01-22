    public static bool IsNullOrEmptyTrimmed(string value)
    {
        if (value == null || value.Trim().Length == 0)
            return true;
        else
            return IsNullOrEmptyTrimmed(value.Trim());
    }
