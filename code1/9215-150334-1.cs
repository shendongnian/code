      if (!dailyCountList.Any())
          return;
      //make a dictionary to provide O(1) lookups for later
      Dictionary<DateTime, RegistrationCount> lookup = dailyCountList.ToDictionary(r => r.EventDateTime);
      DateTime minDate = dailyCountList.Min(r => r.EventDateTime);
      DateTime maxDate = dailyCountList.Max(r => r.EventDateTime);
      int DayCount = 1 + (int) (maxDate - minDate).TotalDays;
      // I have the days now.
      List<DateTime> allDates = Enumerable
        .Range(0, DayCount)
        .Select(x => minDate.AddDays(x))
        .ToList();
      //project the days into RegistrationCounts, making up the missing ones.
      List<RegistrationCount> result = allDates
          .Select(d => lookup.ContainsKey(d) ? lookup[d] :
              new RegistrationCount(){EventDateTime = d, Count = 0})
          .ToList();
