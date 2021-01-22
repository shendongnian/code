    public static class DateTimeWithZone
    {
    
    private static readonly TimeZoneInfo timeZone;
    static DateTimeWithZone()
    {
    //I added web.config <add key="CurrentTimeZoneId" value="Central Europe Standard Time" />
    //You can add value directly into function.
        timeZone = TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["CurrentTimeZoneId"]);
    }
    
    public static DateTime LocalTime(this DateTime t)
    {
         return TimeZoneInfo.ConvertTime(t, timeZone);   
    }
    }
