    TimeZoneInfo tz;
    try
    {
        // Linux
        tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
    }
    catch (TimeZoneNotFoundException)
    {
        try
        {
            // Windows
            tz = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
        }
        catch (TimeZoneNotFoundException)
        {
            // Fallback to UTC
            tz = TimeZoneInfo.Utc;
        }
    }
    
    var converted = tz.ConvertTimeFromUtc(DateTime.UtcNow);
