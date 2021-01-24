	static void Main(string[] args)
	{
		Console.WriteLine(GetIsLeapDateTime(1358));
		Console.WriteLine(GetIsLeapDateTime(1359));
		Console.WriteLine(GetIsLeapDateTime(1360));
		Console.WriteLine(GetIsLeapDateTime(1361));
		Console.WriteLine(GetIsLeapDateTime(1362));
		Console.WriteLine(GetIsLeapDateTime(1363));
		Console.WriteLine(GetIsLeapDateTime(1364));
		Console.WriteLine(GetIsLeapDateTime(1365));
		Console.WriteLine(GetIsLeapDateTime(1366));
		Console.ReadLine();
	}
	private static bool GetIsLeapDateTime(int year, int month = 10, int day = 11, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
	{
		bool isLeap = false;
		PersianCalendar pc = new PersianCalendar();
		DateTime gregorian = pc.ToDateTime(year, month, day, hour, minute, second, millisecond);
		if (DateTime.IsLeapYear(gregorian.Year))
		{
			isLeap = true;
		}
		return isLeap;
	}
