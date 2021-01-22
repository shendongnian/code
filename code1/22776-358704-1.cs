    public static void UninstallService(string ExeFilename)
    {
    
        System.Configuration.Install.AssemblyInstaller Installer = new  System.Configuration.Install.AssemblyInstaller(ExeFilename);
    
        Installer.UseNewContext = true;
    
        Installer.Uninstall(null);
    
    }
