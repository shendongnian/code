	public static void Main(string[] args)
	{
		var sc = new ShiftConfig(
			new ShiftInfo(TimeSpan.FromHours(0), "night"), 
			new ShiftInfo(TimeSpan.FromHours(8), "early"), 
			new ShiftInfo(TimeSpan.FromHours(16), "late"));
		Console.WriteLine("                      |          SHIFT          |          WORK           ");
		Console.WriteLine("   Date    Shiftname  |   from    until   dur.  |   from    until   dur.  ");
		Console.WriteLine("======================|=========================|=========================");
		foreach (var item in sc.EnumerateShifts(new DateTime(2019, 01, 01, 15, 55, 00), TimeSpan.FromMinutes(20)))
		{
			Console.WriteLine("{0:yyyy-MM-dd} {1,-10} | {2:HH:mm:ss} {3:HH:mm:ss} {4:0.00}h | {5:HH:mm:ss} {6:HH:mm:ss} {7:0.00}h", item.ShiftFrom.Date, item.Shift.Name, item.ShiftFrom, item.ShiftUntil, item.ShiftDuration.TotalHours, item.WorkFrom, item.WorkUntil, item.WorkDuration.TotalHours);
		}
	}
