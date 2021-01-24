	try
	{
		Console.WriteLine("Testing invalid constrcutor");
		var test = new Test(new DateTime(2007, 12, 01));
	}
	catch (ArgumentOutOfRangeException e)
	{
		Console.WriteLine(e.Message);
	}
