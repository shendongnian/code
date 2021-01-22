	DateTime date = new DateTime(2009, 3, 12);
	DayOfWeek day = DayOfWeek.Sunday;
	DateTime nextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1);
	while (nextMonth.DayOfWeek != day) {
		nextMonth = nextMonth.AddDays(1);
	}
	DateTime lastInMonth = nextMonth.AddDays(-7);
