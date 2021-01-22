		private static int getWeeksSpannedBy(DateTime first, DateTime last)
		{
			var calendar = CultureInfo.CurrentCulture.Calendar;
			var weekRule = CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule;
			var firstDayOfWeek = DayOfWeek.Sunday;
			int lastWeek = calendar.GetWeekOfYear(last, weekRule, firstDayOfWeek);
			int firstWeek = calendar.GetWeekOfYear(first, weekRule, firstDayOfWeek);
			int weekDiff = lastWeek - firstWeek + 1;
			return weekDiff;
		}
		static void Main(string[] args)
		{
			int weeks1 = getWeeksSpannedBy(new DateTime(2010, 1, 3), new DateTime(2010, 1, 9));
			int weeks2 = getWeeksSpannedBy(new DateTime(2010, 10, 16), new DateTime(2010, 10, 31));
			Console.WriteLine("Weeks Difference #1: " + weeks1);
			Console.WriteLine("Weeks Difference #2: " + weeks2);
			Console.ReadLine();
		}
