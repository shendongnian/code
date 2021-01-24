    //Saves the time in your own timezone
    DateTime a = Convert.ToDateTime(DateTime.UtcNow.ToString("s") + "Z");
    var result = a.AddHours(-4);
    //1h @ middle europe (berlin,...)
    Console.WriteLine("Local Timezone offset: " + TimeZoneInfo.Local.BaseUtcOffset);
    //not mentioned above: + 1h daylight saving time in germany
    
    //local times
    System.Console.WriteLine("local:\t\t" + a.ToString("s")); //2018-05-29T12:34:26
    System.Console.WriteLine("local -4h:\t" + result.ToString("s")); //2018-05-29T08:34:26
    
    //utc times
    System.Console.WriteLine("utc:\t\t" + DateTime.UtcNow.ToString("s")); //2018-05-29T10:34:26
    var utctime = TimeZoneInfo.ConvertTime(result, TimeZoneInfo.Utc);
    System.Console.WriteLine("utc -4h:\t" + utctime.ToString("s")); //2018-05-29T06:34:26
