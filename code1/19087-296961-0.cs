	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(DateTime.Now.ToLongTimeString().ToString());
			Console.WriteLine(DateTime.Now.ToShortTimeString().ToString());
			Console.ReadLine();
		}
	}
