	private static void Main(string[] args)
	{
		if (!IsRunAsAdmin())
		{
			ProcessStartInfo proc = new ProcessStartInfo();
			proc.UseShellExecute = true;
			proc.WorkingDirectory = Environment.CurrentDirectory;
			proc.FileName = Assembly.GetEntryAssembly().CodeBase;
			foreach (string arg in args)
			{
				proc.Arguments += String.Format("\"{0}\" ", arg);
			}
			proc.Verb = "runas";
			try
			{
				Process.Start(proc);
			}
			catch
			{
				Console.WriteLine("This application requires elevated credentials in order to operate correctly!");
			}
		}
        else
        {
            //Normal program logic...
        }
	}
	private static bool IsRunAsAdmin()
	{
		WindowsIdentity id = WindowsIdentity.GetCurrent();
		WindowsPrincipal principal = new WindowsPrincipal(id);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
