	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		private static void Main(string[] args)
		{
			if (args.Length > 0 && args[0] == "/form")
			{
				var form = new MainForm();
				Application.Run(form);
				return;
			}
			var ServicesToRun = new ServiceBase[]
  		        {
  			        new BackgroundService()
  		        };
			ServiceBase.Run(ServicesToRun);
		}
	}
