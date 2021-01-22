	public static readonly string UNINSTALL_REG_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
	public static readonly string UNINSTALL_REG_GUID = "{1C2301A...YOUR GUID HERE}";
	
	using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(UNINSTALL_REG_KEY, true))
	{
		try
		{
			RegistryKey key = null;
			try
			{
				key = parent.OpenSubKey(UNINSTALL_REG_GUID, true);
				if (key == null)
				{
					key = parent.CreateSubKey(UNINSTALL_REG_GUID);
				}
				Assembly asm = typeof (Service).Assembly;
				Version v = asm.GetName().Version;
				string exe = "\"" + asm.CodeBase.Substring(8).Replace("/", "\\\\") + "\"";
				key.SetValue("DisplayName", DISPLAY_NAME);
				key.SetValue("ApplicationVersion", v.ToString());
				key.SetValue("Publisher", "Company Name");
				key.SetValue("DisplayIcon", exe);
				key.SetValue("DisplayVersion", v.ToString(2));
				key.SetValue("URLInfoAbout", "http://www.company.com");
				key.SetValue("Contact", "support@company.com");
				key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
				key.SetValue("UninstallString", exe + " /uninstallprompt");
			}
			finally
			{
				if (key != null)
				{
					key.Close();
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception(
				"An error occurred writing uninstall information to the registry.  The service is fully installed but can only be uninstalled manually through the command line.",
				ex);
		}
	}
