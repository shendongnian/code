    using Microsoft.Win32;
    
    RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
    using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
    {
        RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
        if (instanceKey != null)
        {
            foreach (var instanceName in instanceKey.GetValueNames())
            {
                Console.WriteLine(Environment.MachineName + @"\" + instanceName);
            }
        }
    }
