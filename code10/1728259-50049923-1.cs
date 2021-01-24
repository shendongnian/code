    int dayOffset = availability.Day - (int)DateTime.Today.DayOfWeek;
    if (dayOffset < 0)
    {
    	dayOffset += 7;
    }
    
    var openingHourStart = DateTime
                           .SpecifyKind(DateTime.Today, DateTimeKind.Unspecified)
                           .AddDays(dayOffset)
                           .AddMilliseconds(availability.Time);
 
    var sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(availability.TimeZoneId);
    var userTimeZone = TimeZoneInfo.Local;
    var convertedOpeningHourStart = TimeZoneInfo.ConvertTime(openingHourStart,
                                                             sourceTimeZone,
                                                             userTimeZone);
