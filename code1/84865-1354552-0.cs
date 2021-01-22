    var info = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
    DateTimeOffset localServerTime = DateTimeOffset.Now;
    DateTimeOffset usersTime = TimeZoneInfo.ConvertTime(localServerTime, info);
    DateTimeOffset utc = usersTime.ToUniversalTime();
    Console.WriteLine("Local Time:  {0}", localServerTime);
    Console.WriteLine("User's Time: {0}", usersTime);
    Console.WriteLine("UTC:         {0}", utc);
