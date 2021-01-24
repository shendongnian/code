      List<TimeSpan> lstDT = new List<TimeSpan>() {
        new TimeSpan( 1,  0, 0), 
        new TimeSpan( 6,  0, 0), // pure times, no date parts
        new TimeSpan(12, 30, 0),
        new TimeSpan(17, 45, 0),
      };
      // Test Data:
      // DateTime current = new DateTime(2018, 10, 27, 11, 20, 0);
      // TimeSpan CurrentTimeSpan = TimeSpan.FromTicks(current.TimeOfDay.Ticks);
      // TimeOfDay - we don't want Date part, but Time only
      TimeSpan CurrentTimeSpan = TimeSpan.FromTicks(DateTime.Now.TimeOfDay.Ticks);
      var min = lstDT
        .Select(x => new {
           // new TimeSpan(1, 0, 0, 0) - over the midnight
           diff = Math.Min(Math.Abs((x - CurrentTimeSpan).Ticks),
                           Math.Abs((x - CurrentTimeSpan + new TimeSpan(1, 0, 0, 0)).Ticks)),
          time = x
        })
        .OrderBy(x => x.diff)
        .First()              // <- First, not Last
        .time;
