		[Flags]
		public enum DaysOfWeek
		{
			Sunday = 1,
			Monday = 2,
			Tuesday = 4,
			Wednesday = 8,
			Thursday = 16,
			Friday = 32,
			Saturday = 64
		}
		public void RunOnDays(DaysOfWeek days)
		{
			bool isTuesdaySet = days.HasFlag(DaysOfWeek.Tuesday);
			if (isTuesdaySet)
			{
				//...
			}
		}
		public void CallMethodWithTuesdayAndThursday()
		{
			RunOnDays(DaysOfWeek.Tuesday | DaysOfWeek.Thursday);
		}
