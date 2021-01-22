	class MainClass
	{
		private static bool keepRunning = true;
		public static void Main(string[] args)
		{
			Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) {
				e.Cancel = true;
				MainClass.keepRunning = false;
			};
			
			while (MainClass.keepRunning) {
                // Do your work in here, in small chunks.
                // If you literally just want to wait until ctrl-c,
                // not doing anything, see the answer using set-reset events.
            }
			Console.WriteLine("exited gracefully");
		}
	}
