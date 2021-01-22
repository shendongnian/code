    // strings
    public static bool NullBlankCheck(this string s, string message = "",
        bool throwEx = true)
    {
        return Check<NullReferenceException>(s.IsNullOrBlank(), throwEx, message);
    }
    public static bool NullBlankCheckArgument(this string s, string message = "",
        bool throwEx = true)
    {
        return Check<ArgumentException>(s.IsNullOrBlank(), throwEx, message);
    }
    private static bool Check<T>(bool isNull, bool throwEx, string exceptionMessage)
        where T : Exception
    {
        if (throwEx && isNull)
            throw Activator.CreateInstance(typeof(T), exceptionMessage) as Exception;
        return isNull;
    }
    public static bool IsNullOrBlank(this string s)
    {
        return string.IsNullOrEmpty(s) || s.Trim().Length == 0;
    }
