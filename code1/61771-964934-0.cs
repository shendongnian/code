    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        
    // Prints True
    Console.WriteLine(tzi.IsDaylightSavingTime(new DateTime(2009, 6, 1)));
    // Prints False
    Console.WriteLine(tzi.IsDaylightSavingTime(new DateTime(2009, 1, 1)));
