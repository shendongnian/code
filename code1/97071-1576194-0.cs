    public static DateTime Parse(string s)
    {
        return DateTimeParse.Parse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None);
    }
    
    public static bool TryParse(string s, out DateTime result)
    {
        return DateTimeParse.TryParse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out result);
    }
