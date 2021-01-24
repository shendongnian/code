    // On Windows:
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTime dt = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);
    // On Linux/OSX:
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
    DateTime dt = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);
