    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    using (var key = hklm.CreateSubKey(@"SOFTWARE\FolderName", writable: true))
    {
        // do stuff with the key
        if (key.GetValue("TestKey") == null)
            key.SetValue("TestKey", "456788");
    }
