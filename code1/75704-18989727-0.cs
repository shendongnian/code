	/// <summary>
	///     Executed when the service is started.
	/// </summary>
	/// <param name="args">Command line arguments.</param>
	protected override void OnStart(string[] args)
	{
		try
		{
			//How to debug when running a Windows Service:
			// 1. Right click on the service name in Windows Service Manager.
			// 2. Select "Properties".
			// 3. In "Start Parameters", enter "-d" (or "-ebugIntoVisualStudio").
			// 4. Now, when you start the service, it will fire up Visual Studio 2012 and break on the line below.
			// 5. Make sure you have UAC (User Access Control) turned off, and have Administrator privileges.
    #if DEBUG
			if (((ICollection<string>)args).Contains("-d")
			    || ((ICollection<string>)args).Contains("-debugIntoVisualStudio"))
			{
				Debugger.Launch(); // Launches VS2012 debugger.
			}
    #endif
			ShellStart(args);
			base.OnStart(args);
		}
		catch (Exception ex)
		{
            // Log exception here.
		}
	}
