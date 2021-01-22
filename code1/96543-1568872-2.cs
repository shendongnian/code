    RegistryKey rkey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "RemoteComputer");
    RegistryKey rkeySoftware = rkey.OpenSubKey("Software");
    RegistryKey rkeyVendor = rkeySoftware.OpenSubKey("VendorName");
    RegistryKey rkeyVersions = rkeyVendor.OpenSubKey("Versions");
           
    String[] ValueNames = rkeyVersions.GetValueNames();
    foreach (string name in ValueNames)
    {
        MessageBox.Show(name + ": " + rkeyVersions.GetValue(name).ToString());
    }
