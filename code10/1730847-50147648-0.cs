    string datetime = "24-02-2018 07:30:00";
    DateTime databaseUtcTime = DateTime.ParseExact(datetime,"dd-MM-yyyy HH:mm:ss",null);
    Console.WriteLine("System Date : {0}", databaseUtcTime);
    var japaneseTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
    var japaneseTime = TimeZoneInfo.ConvertTimeFromUtc(databaseUtcTime, japaneseTimeZone);
    Console.WriteLine("Japan Date : {0}", japaneseTime);
