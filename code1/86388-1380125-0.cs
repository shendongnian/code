    public bool IsProgramInstalled(string displayName)
    {
          string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
          using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
          {
                foreach (string skName in rk.GetSubKeyNames())
                {
                      using (RegistryKey sk = rk.OpenSubKey(skName))
                      {
                            if(sk.GetValue("DisplayName") == displayName))
                            {
                                return true;
                            }
                      }
                }
          }
          return false;
    }
