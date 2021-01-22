        private string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }
            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            if (!Environment.Is64BitOperatingSystem)
            {
                using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
                {
                    string currentVersion = rk.GetValue("CurrentVersion").ToString();
                    using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                    {
                        return key.GetValue("JavaHome").ToString();
                    }
                }
            }
            else
            {
                using (var view64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                                            RegistryView.Registry64))
                {
                    using (var clsid64 = view64.OpenSubKey(javaKey))
                    {
                        string currentVersion = clsid64.GetValue("CurrentVersion").ToString();
                        using (RegistryKey key = clsid64.OpenSubKey(currentVersion))
                        {
                            return key.GetValue("JavaHome").ToString();
                        }
                    }
                }
            }
        }
