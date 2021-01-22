    public static bool IisInstalled()
            {
                try
                {
                    using (RegistryKey iisKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp"))
                    {
                        return (int)iisKey.GetValue("MajorVersion") >= 6;
                    }
                }
                catch
                {
                    return false;
                }
            }
