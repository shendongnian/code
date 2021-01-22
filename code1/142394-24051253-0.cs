    // you said you had these already
    DateTime utc = new DateTime(2014, 6, 4, 12, 34, 0);
    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    // it's a simple one-liner
    DateTime pacific = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
