    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTime dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now,
         TimeZoneInfo.IsDaylightSavingsTime(tzi) ? 
            tzi.DaylightName : tzi.StandardName);
    if (dt.Hour == 17)
        ....
