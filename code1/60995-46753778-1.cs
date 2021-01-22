            public static class DotNetHelper
    {
        public static Version InstalledVersion
        {
            get
            {
                string framework = null;
                try
                {
                    using (var ndpKey =
                Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                    {
                        if (ndpKey != null)
                        {
                            var releaseKey = ndpKey.GetValue("Release");
                            if (releaseKey != null)
                            {
                                framework = CheckFor45PlusVersion(Convert.ToInt32(releaseKey));
                            }
                            else
                            {
                                string[] versionNames = null;
                                using (var installedVersions =
                                    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP"))
                                {
                                    if (installedVersions != null) versionNames = installedVersions.GetSubKeyNames();
                                }
                                try
                                {
                                    if (versionNames != null && versionNames.Length > 0)
                                    {
                                        framework = versionNames[versionNames.Length - 1].Remove(0, 1);
                                    }
                                }
                                catch (FormatException)
                                {
                                }
                            }
                        }
                    }
                }
                catch (SecurityException)
                {
                }
                return framework != null ? new Version(framework) : null;
            }
        }
        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return releaseKey >= 378389 ? "4.5" : null;
        }
    }
