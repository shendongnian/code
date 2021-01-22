	ProcessStartInfo info = new ProcessStartInfo("explorer.exe", myDriveLetter);
	info.WindowStyle = ProcessWindowStyle.Hidden;
	Process process = new Process();
	process.StartInfo = info;
	process.Start();
	Thread.Sleep(1000);
	//bool res = process.CloseMainWindow();	// doesn't work for explorer !!
	//process.Close();
	//process.WaitForExit(5000);
	// https://stackoverflow.com/a/47574704/2925238
	ShellWindows _shellWindows = new SHDocVw.ShellWindows();
	string processType;
	foreach (InternetExplorer ie in _shellWindows)
	{
		//this parses the name of the process
		processType = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
		//this could also be used for IE windows with processType of "iexplore"
		if (processType.Equals("explorer") && ie.LocationURL.Contains(myDriveLetter))
		{
			ie.Quit();
		}
	}
