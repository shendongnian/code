    var tz = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
    
    TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018,1,1,0,0,0,DateTimeKind.Utc), tz); 
        // => 01/01/2018 11:00:00
    TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018,7,1,0,0,0,DateTimeKind.Utc), tz); 
        // => 01/07/2018 10:00:00
