        private static Version GetFrameworkVersion()
        {
            using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"))
            {
                if (ndpKey != null)
                {
                    int value = (int)(ndpKey.GetValue("Release") ?? 0);
                    if (value >= 461308)
                        return new Version(4, 7, 1);
                    if (value >= 460798)
                        return new Version(4, 7, 0);
                    if (value >= 394802)
                        return new Version(4, 6, 2);
                    if (value >= 394254)
                        return new Version(4, 6, 1);
                    if (value >= 393295)
                        return new Version(4, 6, 0);
                    if (value >= 379893)
                        return new Version(4, 5, 2);
                    if (value >= 378675)
                        return new Version(4, 5, 1);
                    if (value >= 378389)
                        return new Version(4, 5, 0);
                    throw new NotSupportedException($"No 4.5 or later framework version detected, framework key value: {value}");
                }
                throw new NotSupportedException(@"No registry key found under 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full' to determine running framework version");
            }
        }
