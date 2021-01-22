    public static string GetDefaultBrowserPath()
        {
            string defaultBrowserPath = null;
            RegistryKey regkey;
            // Check if we are on Vista or Higher
            OperatingSystem OS = Environment.OSVersion;
            if ((OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6))
            {
                regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\shell\\Associations\\UrlAssociations\\http\\UserChoice", false);
                if (regkey != null)
                {
                    defaultBrowserPath = regkey.GetValue("Progid").ToString();
                }
                else
                {
                    regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\IE.HTTP\\shell\\open\\command", false);
                    defaultBrowserPath = regkey.GetValue("").ToString();
                }
            }
            else
            {
                regkey = Registry.ClassesRoot.OpenSubKey("http\\shell\\open\\command", false);
                defaultBrowserPath = regkey.GetValue("").ToString();
            }
            return defaultBrowserPath;
        }
