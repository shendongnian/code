	public static void Main()
	{
        // 12 for december as example
		var current = new DateTime(DateTime.Now.Year, 12, DateTime.Now.Day);
		var next  = current.AddMonths(1);
		Console.WriteLine(DateTime.DaysInMonth(next.Year, next.Month));
	}
