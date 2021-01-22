	public static class TimeSpanExtensions
	{
		public static string ToReadableString(this TimeSpan timeSpan)
		{
			int days = (int)(timeSpan.Ticks / TimeSpan.TicksPerDay);
			long subDayTicks = timeSpan.Ticks % TimeSpan.TicksPerDay;
	
			bool isNegative = false;
			if (timeSpan.Ticks < 0L)
			{
				isNegative = true;
				days = -days;
				subDayTicks = -subDayTicks;
			}
	
			int hours = (int)((subDayTicks / TimeSpan.TicksPerHour) % 24L);
			int minutes = (int)((subDayTicks / TimeSpan.TicksPerMinute) % 60L);
			int seconds = (int)((subDayTicks / TimeSpan.TicksPerSecond) % 60L);
			int subSecondTicks = (int)(subDayTicks % TimeSpan.TicksPerSecond);
			double fractionalSeconds = (double)subSecondTicks / TimeSpan.TicksPerSecond;
	
			var parts = new List<string>(4);
	
			if (days > 0)
				parts.Add(string.Format("{0} day{1}", days, days == 1 ? null : "s"));
			if (hours > 0)
				parts.Add(string.Format("{0} hour{1}", hours, hours == 1 ? null : "s"));
			if (minutes > 0)
				parts.Add(string.Format("{0} minute{1}", minutes, minutes == 1 ? null : "s"));
			if (fractionalSeconds.Equals(0D))
			{
				switch (seconds)
				{
					case 0:
						// Only write "0 seconds" if we haven't written anything at all.
						if (parts.Count == 0)
							parts.Add("0 seconds");
						break;
	
					case 1:
						parts.Add("1 second");
						break;
	
					default:
						parts.Add(seconds + " seconds");
						break;
				}
			}
			else
			{
				parts.Add(string.Format("{0}{1:.###} seconds", seconds, fractionalSeconds));
			}
	
			string resultString = string.Join(", ", parts);
			return isNegative ? "(negative) " + resultString : resultString;
		}
	}
