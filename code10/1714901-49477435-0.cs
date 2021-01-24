     public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            
            //Convert in my timezone
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            DateTime userTime = TimeZoneInfo.ConvertTimeFromUtc(dtDateTime, timeInfo);
            return userTime;
        }
