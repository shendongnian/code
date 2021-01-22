	AppDomainSetup adSetup = new AppDomainSetup();
	if (AppDomain.CurrentDomain.SetupInformation.ShadowCopyFiles == "true")
	{
		var shadowCopyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		if (shadowCopyDir.Contains("assembly"))
			shadowCopyDir = shadowCopyDir.Substring(0, shadowCopyDir.LastIndexOf("assembly"));
		var privatePaths = new List<string>();
		foreach (var dll in Directory.GetFiles(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "*.dll"))
		{
			var shadowPath = Directory.GetFiles(shadowCopyDir, Path.GetFileName(dll), SearchOption.AllDirectories).FirstOrDefault();
			if (!String.IsNullOrWhiteSpace(shadowPath))
				privatePaths.Add(Path.GetDirectoryName(shadowPath));
		}
		adSetup.ApplicationBase = shadowCopyDir;
		adSetup.PrivateBinPath = String.Join(";", privatePaths);
	}
	else
	{
		adSetup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
		adSetup.PrivateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
	}
