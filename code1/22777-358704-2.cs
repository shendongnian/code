    public static void InstallService(string exeFilename)
    {
        string[] commandLineOptions = new string[1] { "/LogFile=install.log" };
    
        System.Configuration.Install.AssemblyInstaller installer = new System.Configuration.Install.AssemblyInstaller(exeFilename, commandLineOptions);
    
        installer.UseNewContext = true;    
        installer.Install(null);    
        installer.Commit(null);
    
    }
