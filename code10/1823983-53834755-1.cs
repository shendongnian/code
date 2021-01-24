     var scoreTimePeriod = new InsurerTimePeriodScoreSetting
     {
         // start of insurer's time period. 18/12 22:00
          StartOfTimePeriod = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0, DateTimeKind.Utc),   // DateTime.Now + TimeSpan.FromHours(22),
         // end of insurer's time period. 19/12 6:00
         EndOfTimePeriod = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 6, 0, 0, DateTimeKind.Utc)  // DateTime.Now + TimeSpan.FromHours(30)
     };
