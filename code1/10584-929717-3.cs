	class MainClass
	{
		private static bool keepRunning = true;
		public static void Main(string[] args)
		{
			Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) {
				e.Cancel = true;
				MainClass.keepRunning = false;
			};
			
			while (MainClass.keepRunning) {}
			Console.WriteLine("exited gracefully");
		}
	}
