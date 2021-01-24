    using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                               Environment.Is64BitOperatingSystem
                                          ? RegistryView.Registry64
                                          : RegistryView.Registry32))
    {
        using (var key = root.OpenSubKey(@"SOFTWARE\Test Key\dev", false))
        {
            var myVal= key.GetValue("Enable");
            MessageBox.Show(myVal.ToString());
        }
    }
