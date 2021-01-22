    public static bool CheckSQLInstalled()
        {
            bool isOk1 = false;
            bool isOk2 = false;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            if (Environment.Is64BitOperatingSystem)
            {
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                    if (instanceKey != null)
                    {
                        foreach (var instanceName in instanceKey.GetValueNames())
                        {                           
                            isOk2 = true;
                            break;
                        }
                    }
                }
            }
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        isOk1 = true;
                        break;
                    }
                }
            }
            return isOk1 || isOk2;
        }
        public static bool CheckInstanceInstalled()
        {
            bool isOk1 = false;
            bool isOk2 = false;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            if (Environment.Is64BitOperatingSystem)
            {
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                    if (instanceKey != null)
                    {
                        foreach (string instanceName in instanceKey.GetValueNames())
                        {
                            if (instanceName.ToUpperInvariant() == "DATABASE_NAME")
                            {
                                isOk2 = true;
                                break;
                            }
                        }
                    }
                }
            }
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        if (instanceName.ToUpperInvariant() == "DATABASE_NAME")
                        {
                            isOk1 = true;
                            break;
                        }
                    }
                }
            }
            return isOk1 || isOk2;
        }
