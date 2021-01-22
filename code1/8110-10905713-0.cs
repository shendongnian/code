	if (IsAdministrator() == false)
	{
		// Restart program and run as admin
		var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
		ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
		startInfo.Verb = "runas";
		System.Diagnostics.Process.Start(startInfo);
		Application.Current.Shutdown();
		return;
	}
	private static bool IsAdministrator()
	{
		WindowsIdentity identity = WindowsIdentity.GetCurrent();
		WindowsPrincipal principal = new WindowsPrincipal(identity);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
	// To run as admin, alter exe manifest file after building.
	// Or create shortcut with "as admin" checked.
	// Or ShellExecute(C# Process.Start) can elevate - use verb "runas".
	// Or an elevate vbs script can launch programs as admin.
	// (does not work: "runas /user:admin" from cmd-line prompts for admin pass)
