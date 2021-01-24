	public static string a = string.Empty;
	public static void Main()
	{
		lock(a)
		{
			Console.WriteLine("Hello World");
		}
	}
