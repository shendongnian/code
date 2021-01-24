    var fleTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
    var local = new DateTime(2018, 8, 2, 15, 0, 0, DateTimeKind.Local);
    var utc = local.ToUniversalTime();
    var fle = TimeZoneInfo.ConvertTime(local, fleTimeZone);
    Console.WriteLine(TimeZoneInfo.Local);
    Console.WriteLine(TimeZoneInfo.Local + ": " + local);
    Console.WriteLine(TimeZoneInfo.Utc + ": " + utc);
    Console.WriteLine(fleTimeZone + ": " + fle);
