        TimeZoneInfo chinaTimeZone = TimeZoneInfo.CreateCustomTimeZone(zoneID, TimeSpan.Parse("-08:00"), displayName, standardName);
        DateTime FromTime = new DateTime(2018, 0, 19, 13, 0, 0); // year, month, day, hour, minute, second : Friday 1pm
        DateTime ToTime = new DateTime(2018, 0, 21, 1, 0, 0); // year, month, day, hour, minute, second : Monday 1am
        DateTime nowinUTC = DateTime.UtcNow;
        DateTime nowInChina = TimeZoneInfo.ConvertTimeFromUtc(nowinUTC, chinaTimeZone);
        if(FromTime.Ticks < nowInChina.Ticks && ToTime.Ticks > nowInChina.Ticks)
        {
            // Time is within the from and two times
        }
