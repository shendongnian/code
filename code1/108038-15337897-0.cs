        private readonly TimeSpan Midday = new TimeSpan(12, 0, 0);
		public bool ValidateWeekend(DateTime pickupDate, DateTime dropoffDate)
		{
			TimeSpan lengthOfTrip = dropoffDate.Subtract(pickupDate);
			if (lengthOfTrip.TotalDays < 2 || lengthOfTrip.TotalDays > 4)
				return false;
			return IsPickupDateConsideredWeekend(pickupDate) && IsDropoffDateConsideredWeekend(dropoffDate);
		}
		private bool IsPickupDateConsideredWeekend(DateTime pickupdate)
		{
			if (pickupdate.DayOfWeek == DayOfWeek.Thursday && pickupdate.TimeOfDay > Midday)
				return true;
			return false;
		}
		private bool IsDropoffDateConsideredWeekend(DateTime dropoffDate)
		{
			if (dropoffDate.DayOfWeek == DayOfWeek.Monday && dropoffDate.TimeOfDay <= Midday)
				return true;
			return false;
		}
	
