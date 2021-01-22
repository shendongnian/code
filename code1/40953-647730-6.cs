    public static bool IsNullOrEmptyTrimmed(string value)
    {
        return (value == null || value.Length == 0) ?
            true :
            value.Trim().Length == 0;
    }
