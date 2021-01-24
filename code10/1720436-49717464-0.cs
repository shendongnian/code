    var days = new[] {1, 4, 32};
    var daysOfTheWeek = DaysOfTheWeek.None;
    foreach (var day in days)
    {
        daysOfTheWeek = daysOfTheWeek | (DaysOfTheWeek) day;
    }
    [Flags]
	public enum DaysOfTheWeek
	{
		None = 0,
		Sunday = 1,
		Monday = 2,
		Tuesday = 4,
		Wednesday = 8,
		Thursday = 16,
		Friday = 32,
		Saturday = 64,
		AllDays = 128
	}
