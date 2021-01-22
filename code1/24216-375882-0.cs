    using System;
    using Microsoft.Win32;
    
    
//    ...
    public static string GetFrameworkDirectory()
    {
      // This is the location of the .Net Framework Registry Key
      string framworkRegPath = @"Software\Microsoft\.NetFramework";
    
      // Get a non-writable key from the registry
      RegistryKey netFramework = Registry.LocalMachine.OpenSubKey(framworkRegPath, false);
    
      // Retrieve the install root path for the framework
      string installRoot = netFramework.GetValue("InstallRoot").ToString();
    
      // Retrieve the version of the framework executing this program
      string version = string.Format(@"v{0}.{1}.{2}\",
        Environment.Version.Major, 
        Environment.Version.Minor,
        Environment.Version.Build); 
    
      // Return the path of the framework
      return System.IO.Path.Combine(installRoot, version);     
    }
