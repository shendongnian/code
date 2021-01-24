	static void Main(string[] args)
	{
		try
		{
			Console.WriteLine(Arthimatic(10, 0));
			Console.WriteLine("Hello World!");
			Console.ReadLine();
		}
		catch (DivideByZeroException ex)
		{
			Console.WriteLine(" Message " + ex.Message);
			Console.ReadLine();
		}
	}
	
	private static int Arthimatic(int num1, int num2)
	{
		return Divide(num1, num2);
	}
	
	private static int Divide(int num1, int num2)
	{
		return num1 / num2;
	}
