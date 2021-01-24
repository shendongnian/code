            public static bool? IsDstInTimeZone(DateTime utcDateTime, string timeZoneName)
            {
                if (timeZoneName == null) throw new ArgumentNullException(nameof(timeZoneName));
    
                TimeZoneInfo timeZoneInfo = null;
                try
                {
                    timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
                }
                catch (TimeZoneNotFoundException e)
                {
                    Debug.WriteLine($"TimeZone error: {e.Message}");
                    return null;
                }
                catch(InvalidTimeZoneException e)
                {
                    Debug.WriteLine($"TimeZone error: {e.Message}");
                    return null;
                }
    
    
                return IsDstInTimeZone(utcDateTime, timeZoneInfo);
            }
            public static bool IsDstInTimeZone(DateTime utcDateTime, TimeZoneInfo timeZoneInfo)
            {
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZoneInfo);
                return localTime.IsDaylightSavingTime();
            }
