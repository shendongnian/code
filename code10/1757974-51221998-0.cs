    var tz = TimeZoneInfo.FindSystemTimeZoneById("Sri Lanka Standard Time");
    var midnight = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
    var converted = TimeZoneInfo.ConvertTimeToUtc(midnight, tz);
    Console.WriteLine(midnight); //2000-01-01 00:00:00
    Console.WriteLine(converted);//1999-12-31 18:30:00
