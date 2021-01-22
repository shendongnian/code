	using System;
	
	namespace TestConsole
	{
		class Program
		{
			static void Main(string[] args)
			{
				Console.SetOut(new DebugTextWriter());
				Console.WriteLine("This text goes to the Visual Studio output window.");
			}
		}
	}
