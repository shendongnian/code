    public static DateTime Ago(this TimeSpan value)
    {
        return DateTime.Now.Add(value.Negate());
    }
    public static DateTime FromNow(this TimeSpan value)
    {
       return DateTime.Now.Add(value);
    }
