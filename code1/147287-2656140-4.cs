    public static T ConvertTo<T>(this string value)
    {
        T returnValue = (T)(Enum.Parse(typeof(T), "Unknown", true));
        if ((string.IsNullOrEmpty(value) == false) && 
            (typeof(T).IsEnum))
        {
            try { returnValue = (T)(Enum.Parse(typeof(T), value, true)); }
            catch { }
        }
        return returnValue;
    }
