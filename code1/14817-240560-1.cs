	public DateTime WeekNum(DateTime now)
	{
		DateTime NewNow = now.AddHours(-11).AddDays(6);
		return (NewNow.AddDays(- (int) NewNow.DayOfWeek).Date);
	}
    public void Code(params string[] args)
    {
		
		Console.WriteLine(WeekNum(DateTime.Now));	
		Console.WriteLine(WeekNum(new DateTime(2008,10,27, 10, 00, 00)));
		Console.WriteLine(WeekNum(new DateTime(2008,10,27, 12, 00, 00)));
		Console.WriteLine(WeekNum(new DateTime(2008,10,28)));
		Console.WriteLine(WeekNum(new DateTime(2008,10,25)));
		
		
    }
