	public static void Main(string[] args)
	{
		var sc = new ShiftConfig(
			new ShiftInfo(TimeSpan.FromHours(6), "early"), 
			new ShiftInfo(TimeSpan.FromHours(14), "late"), 
			new ShiftInfo(TimeSpan.FromHours(22), "night"));
		Console.WriteLine("                      |          SHIFT          |          WORK           ");
		Console.WriteLine("   Date    Shiftname  |   from    until   dur.  |   from    until   dur.  ");
		Console.WriteLine("======================|=========================|=========================");
		foreach (var item in sc.EnumerateShifts(new DateTime(2019, 01, 01, 02, 37, 25), TimeSpan.FromHours(28.34)))
		{
			Console.WriteLine("{0:yyyy-MM-dd} {1,-10} | {2:HH:mm:ss} {3:HH:mm:ss} {4:0.00}h | {5:HH:mm:ss} {6:HH:mm:ss} {7:0.00}h", item.ShiftFrom.Date, item.Shift.Name, item.ShiftFrom, item.ShiftUntil, item.ShiftDuration.TotalHours, item.WorkFrom, item.WorkUntil, item.WorkDuration.TotalHours);
		}
	}
