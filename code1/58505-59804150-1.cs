        List<InstalledProgram> installedprograms = new List<InstalledProgram>();
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                {
                    if (subkey.GetValue("DisplayName") != null)
                    {
                        installedprograms.Add(new InstalledProgram
                        {
                            DisplayName = (string)subkey.GetValue("DisplayName"),
                            Version = (string)subkey.GetValue("DisplayVersion"),
                            InstalledDate = (string)subkey.GetValue("InstallDate"),
                            Publisher = (string)subkey.GetValue("Publisher"),
                            UnninstallCommand = (string)subkey.GetValue("UninstallString"),
                            ModifyPath = (string)subkey.GetValue("ModifyPath")
                        });
                    }
                }
            }
        }
