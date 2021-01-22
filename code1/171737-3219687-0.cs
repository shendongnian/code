     public static DateTime GetLocalTime(string TimeZoneName)
        {
            DateTime localDate = System.DateTime.Now.ToUniversalTime();
            // Get the venue time zone info
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);
            TimeSpan timeDiffUtcClient = tz.BaseUtcOffset;
            localDate = System.DateTime.Now.ToUniversalTime().Add(timeDiffUtcClient);
            //DateTimeOffset localDate = new DateTimeOffset(venueTime, tz.BaseUtcOffset);
            if (tz.SupportsDaylightSavingTime && tz.IsDaylightSavingTime(localDate))
            {
                TimeZoneInfo.AdjustmentRule[] rules = tz.GetAdjustmentRules();
                foreach (var adjustmentRule in rules)
                {
                    if (adjustmentRule.DateStart <= localDate && adjustmentRule.DateEnd >= localDate)
                    {
                        localDate = localDate.Add(adjustmentRule.DaylightDelta);
                    }
                }
                //localDate = localDate.Subtract(tz.GetAdjustmentRules().Single(r => localDate >= r.DateStart && localDate <= r.DateEnd).DaylightDelta);
            }
            DateTimeOffset utcDate = localDate.ToUniversalTime();
            return localDate;
        }
