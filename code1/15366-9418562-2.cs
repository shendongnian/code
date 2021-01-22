		public static Dictionary<DayOfWeek, int> TotalDaysOfWeeks(this DateTime firstDate, DateTime lastDate)
		{
			var totalDays = lastDate.Date.Subtract(firstDate.Date).TotalDays + 1;
			var weeks = (int)Math.Floor(totalDays / 7);
			var resultArray = Enumerable.Repeat<int>(weeks, 7).ToArray();
			if (totalDays % 7 != 0)
			{
				int firstDayOfWeek = (int)firstDate.DayOfWeek;
				int lastDayOfWeek = (int)lastDate.DayOfWeek;
				if (lastDayOfWeek < firstDayOfWeek)
					lastDayOfWeek += 7;
				for (int dayOfWeek = firstDayOfWeek; dayOfWeek <= lastDayOfWeek; dayOfWeek++)
					resultArray[dayOfWeek % 7]++;
			}
			var result = new Dictionary<DayOfWeek, int>();
			for (int dayOfWeek = 0; dayOfWeek < 7; dayOfWeek++)
				result[(DayOfWeek)dayOfWeek] = resultArray[dayOfWeek];
			return result;
		}
