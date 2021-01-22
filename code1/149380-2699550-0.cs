    public string GetApplicationPath(string appname)
    {
        using(Microsoft.Win32.RegistryKey key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, ""))
        {
            using(Microsoft.Win32.RegistryKey subkey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + appname))
            {
                if(subkey == null)
                   return "";
                object path = subkey.GetValue("Path");
                
                if(path!=null)
                  return (string)path;
            }
    
        }
        return "";
    }
