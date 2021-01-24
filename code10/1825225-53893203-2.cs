	class Program
	{
		static void Main(string[] args)
		{
			var app = new App_CalcMinMax();
			app.Run();
			if (System.Diagnostics.Debugger.IsAttached)
			{
				Console.WriteLine("\nPress <Enter> to continue...");
				Console.ReadLine();                
			}
		}
	}
