    var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
    //var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
    if (baseKey != null)
    {
        var subKey = baseKey.OpenSubKey("myKey", 
                             RegistryKeyPermissionCheck.ReadWriteSubTree, 
                             RegistryRights.FullControl);
        if (subKey != null)
        {
            subKey.SetValue("hi", "Test");
            subKey.Close();
        }
        baseKey.Close();
    }
