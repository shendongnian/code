    public static IEnumerable<DateTime> AllDatesInWeekOfMonth(int year, int month, int week) {
      DateTime start = new DateTime(year, month, 1);
      start = start
        .AddDays((CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - start.DayOfWeek + 7) % 7)
        .AddDays(week * 7 - 7);
      for (int i = 0; i < 7; ++i)
        if (start.Month == month) {
          yield return start;
          start = start.AddDays(1);
        }
    }
