    public Version GetIisVersion()
    {
        using (RegistryKey componentsKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp", false))
        {
            if (componentsKey != null)
            {
                int majorVersion = (int)componentsKey.GetValue("MajorVersion", -1);
                int minorVersion = (int)componentsKey.GetValue("MinorVersion", -1);
                if (majorVersion != -1 && minorVersion != -1)
                {
                    return new Version(majorVersion, minorVersion);
                }
            }
            return new Version(0, 0);
        }
    }
