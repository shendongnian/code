		int[] CountDays(DateTime firstDate, DateTime lastDate)
		{
			var totalDays = lastDate.Date.Subtract(firstDate.Date).TotalDays + 1;
			var weeks = (int)Math.Floor(totalDays / 7);
			var result = Enumerable.Repeat<int>(weeks, 7).ToArray();
			if (totalDays % 7 != 0)
			{
				int firstDayOfWeek = (int)firstDate.DayOfWeek;
				int lastDayOfWeek = (int)lastDate.DayOfWeek;
				if (lastDayOfWeek < firstDayOfWeek)
					lastDayOfWeek += 7;
				for (int dayOfWeek = firstDayOfWeek; dayOfWeek <= lastDayOfWeek; dayOfWeek++)
					result[dayOfWeek % 7]++;
			}
			return result;
		}
