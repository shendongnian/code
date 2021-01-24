    // On Windows:
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTimeOffset dto = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tz);
    // On Linux/OSX:
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
    DateTimeOffset dto = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tz);
