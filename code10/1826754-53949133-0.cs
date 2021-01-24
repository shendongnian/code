    var now = DateTime.Now;
    Console.WriteLine(now.Kind);
    var centralTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, "Central Standard Time");
    Console.WriteLine(centralTime.Kind);
    var mountainTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, "Mountain Standard Time");
    Console.WriteLine(mountainTime.Kind);
