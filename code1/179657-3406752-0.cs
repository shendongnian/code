    public static string AsNullIfEmpty(this string str)
    {
        if (!string.IsNullOrEmpty(str))
            return str;
        return null;
    }
