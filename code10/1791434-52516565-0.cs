	void Main()
	{
		UseFilterThenCatch();
		UseFilterOnly();
	}
	
	public static bool BadFilter() => throw new Exception("This will be thrown by the filter");
	
	public static void UseFilterThenCatch()
	{
		try
		{
			throw new Exception("The exception to catch.");
		}
		catch(Exception) when (BadFilter())
		{
			Console.WriteLine("Filtered");
		}
		catch(Exception e)
		{
			Console.WriteLine("Unfiltered"); // This line gets hit.
			Console.WriteLine(e.Message); // This proves it's the first exception thrown.
		}
	}
	
	public static void UseFilterOnly()
	{
		try
		{
			try
			{
				throw new Exception("The exception to catch.");
			}
			catch (Exception) when (BadFilter())
			{
				Console.WriteLine("Filtered");
			}
		}
		catch(Exception e)
		{
			Console.WriteLine("Outer catch");
			Console.WriteLine(e.Message); // This proves it's the first exception thrown.
		}
	}
