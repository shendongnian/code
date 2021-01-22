    public static string Truncate(this string s, int length)
    {
        return string.IsNullOrEmpty(s) || s.Length <= length ? s 
            : length <= 0 ? string.Empty 
            : s.Substring(0, length);
    }
