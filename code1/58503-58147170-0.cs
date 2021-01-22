    List<string> installs = new List<string>();
    List<string> keys = new List<string>() {
      @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
      @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
    };
    // The RegistryView.Registry64 forces the application to open the registry as x64 even if the application is compiled as x86 
    FindInstalls(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64), keys, installs);
    FindInstalls(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64), keys, installs);
    installs = installs.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
    installs.Sort(); // The list of ALL installed applications
    private void FindInstalls(RegistryKey regKey, List<string> keys, List<string> installed)
    {
      foreach (string key in keys)
      {
        using (RegistryKey rk = regKey.OpenSubKey(key))
        {
          if (rk == null)
          {
            continue;
          }
          foreach (string skName in rk.GetSubKeyNames())
          {
            using (RegistryKey sk = rk.OpenSubKey(skName))
            {
              try
              {
                installed.Add(Convert.ToString(sk.GetValue("DisplayName")));
              }
              catch (Exception ex)
              { }
            }
          }
        }
      }
    }
