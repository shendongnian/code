    public static void UninstallService(string exeFilename)
    {
        string[] commandLineOptions = new string[1] { "/LogFile=uninstall.log" };
        System.Configuration.Install.AssemblyInstaller installer = new System.Configuration.Install.AssemblyInstaller(exeFilename, commandLineOptions);
    
        installer.UseNewContext = true;    
        installer.Uninstall(null);
    
    }
