	static void Main(string[] args)
	{
		if (Arthimatic(10, 0) == null)
		{
			Console.WriteLine("An Error Occurred.");
		}
		else
		{
			Console.WriteLine("Hello World!");
		}
	}
	
	private static int? Arthimatic(int num1, int num2)
	{
		return Divide(num1, num2);
	}
	
	private static int? Divide(int num1, int num2)
	{
		try
		{
			return num1 / num2;
		}
		catch (DivideByZeroException ex)
		{
			return null;
		}
	}
