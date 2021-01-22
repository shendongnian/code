    var allDailyCountList =
       from d in Range(dc[0].EventDateTime, dc[dc.Count - 1].EventDateTime) 
       // since you already ordered by DateTime, we don't have to search the entire List
       join dc in dailyCountList on
          d equals dc.EventDateTime
       into rcGroup
       from rc in rcGroup.DefaultIfEmpty(
          new RegistrationCount()
          {
             EventDateTime = d,
             Count = 0
          }
       ) // gives us a left join
       select rc;
    public static IEnumerable<DateTime> Range(DateTime start, DateTime end) {
       for (DateTime date = start, date <= end; date = date.AddDays(1)) {
          yield return date;
       }
    }
