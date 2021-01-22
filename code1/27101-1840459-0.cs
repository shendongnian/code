    // Get time in local time zone 
    DateTime thisTime = DateTime.Now;
    Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(thisTime) ?
                      TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, thisTime);
    Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local));
    // Get Tokyo Standard Time zone
    TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
    DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);      
    Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(tstTime) ?
                      tst.DaylightName : tst.StandardName, tstTime);
    Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));
