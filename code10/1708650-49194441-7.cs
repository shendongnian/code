    using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    {
        using (var key = root.OpenSubKey(@"SOFTWARE\Test Key\dev", false))
        {
            var myVal= key.GetValue("Enable");
            MessageBox.Show(myVal.ToString());
        }
    }
