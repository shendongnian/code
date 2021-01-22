    	RegistryKey uninstall = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
		List<string> applicationList = new List<string>();
		foreach (string subKeyName in uninstall.GetSubKeyNames())
		{
			RegistryKey subKey = uninstall.OpenSubKey(subKeyName);
			string applicationName = subKey.GetValue("DisplayName", String.Empty).ToString();
			if (!String.IsNullOrEmpty(applicationName))
			{
				applicationList.Add(applicationName);
			}
			subKey.Close();
		}
		
		uninstall.Close();
		
		applicationList.Sort();
		
		foreach (string name in applicationList)
		{
			Console.WriteLine(name);	
		}
