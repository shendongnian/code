    public static IEnumerable<DateTime> GetFirstWeek(int month, int year)
		{
			var firstDay = new DateTime(year, month, 1);
			var dayOfWeek = firstDay.DayOfWeek;
			var firstWeekDay = firstDay.AddDays(-(int)dayOfWeek);
			for (int i = 0; i < 7; i++)
			{
				yield return firstWeekDay.AddDays(i);
			}
		}
