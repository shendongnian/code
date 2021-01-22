    Private static string PathName
    { 
        get
        {
             using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Copium"))
             {
                  return (string)registryKey.GetValue("BinDir");
             }
        }
    }
