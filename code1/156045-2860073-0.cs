    public static class MyExtentions
	{
		public static void LogToErrorFile(this Exception exception)
		{
			try
			{
				System.IO.File.AppendAllText(System.IO.Path.Combine(Application.StartupPath, "error_log.txt"),
					String.Format("{0}\tProgram Error: {1}\n", DateTime.Now, exception.ToString()));
			}
			catch 
			{ 
				// Handle however you wish
			}
		}
	}
