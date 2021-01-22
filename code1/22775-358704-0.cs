    public static void InstallService(string ExeFilename)
    
    {
    
        System.Configuration.Install.AssemblyInstaller Installer = new  System.Configuration.Install.AssemblyInstaller(ExeFilename);
    
        Installer.UseNewContext = true;
    
        Installer.Install(null);
    
        Installer.Commit(null);
    
    }
