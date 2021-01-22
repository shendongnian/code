    public String IdentifySelfFromRegistry()
    {
        String executionPath = Assembly.GetEntryAssembly().Location;
        Microsoft.Win32.RegistryKey services = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                @"SYSTEM\CurrentControlSet\services");
        if (services != null)
        {
            foreach(String subkey in services.GetSubKeyNames())
            {
                if (executionPath.Equals(ServicePathFromServiceKey(services.OpenSubKey(subkey))))
                    return subkey;
            }
        }
        return String.Empty;
    }
    protected static String ServicePathFromServiceKey(Microsoft.Win32.RegistryKey serviceKey)
    {
        if (serviceKey != null)
        {
            String exec = serviceKey.GetValue(ServicePathEntry) as String;
            if (exec != null)
                return exec.Trim('\"');
        }
        return String.Empty;
    }
