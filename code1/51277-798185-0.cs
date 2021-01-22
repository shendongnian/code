    	public static void Main()
	{
		System.DateTime _Now = DateAndTime.Now;
		Console.WriteLine("The Date and Time is " + _Now);
		//will return the date and time
		Console.WriteLine("The Date Only is " + _Now.Date);
		//will return only the date
		Console.Write("Press any key to continue . . . ");
		Console.ReadKey(true);
	}
