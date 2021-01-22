    foreach (CalendarWeekRule rule in Enum.GetValues(typeof(CalendarWeekRule)))
    {
        for (int year = 1900; year < 2000; year++)
        {
            DateTime date = FirstDateOfWeek(year, 1, rule);
            Assert(CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, rule, DayOfWeek.Monday) == 1);
            Assert(CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(-1), rule, DayOfWeek.Monday) != 1);
        }
    }
