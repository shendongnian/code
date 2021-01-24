	public static void Main()
	{
		var ts = new TimeSpan(1, 0, 0);
		var format = "hh:mm:ss";
		var unitToIncrement = FindTheUnitAtPos(format, 7);
		Console.WriteLine("original  : {0}", ts);
		Console.WriteLine("increment : {0}", unitToIncrement);
		Console.WriteLine("result    : {0}", ts.Add(unitToIncrement));
		Console.WriteLine();
		
		ts = new TimeSpan(1, 1, 30, 0);
		format = "dd days hh:mm";
		unitToIncrement = FindTheUnitAtPos(format, 1);
		Console.WriteLine("original  : {0}", ts);
		Console.WriteLine("increment : {0}", unitToIncrement);
		Console.WriteLine("result    : {0}", ts.Add(unitToIncrement));
	}
	private static TimeSpan FindTheUnitAtPos(string format, int pos)
	{
		char c = format[pos];
		switch (c)
		{
			case 's': return new TimeSpan(0, 0, 1);
			case 'm': return new TimeSpan(0, 1, 0);
			case 'h': return new TimeSpan(1, 0, 0);
			case 'd': return new TimeSpan(1, 0, 0, 0);
		}
		return new TimeSpan(0, 0, 0);
	}
