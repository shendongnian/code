    public void SetRegistryKey(Microsoft.Win32.RegistryKey regHive, string regKey, string regName, string regValue)
    {
        bool response = false;
    
        Microsoft.Win32.RegistryKey key = regHive.OpenSubKey(regKey);
        if (key == null)
        {
            regHive.CreateSubKey(regKey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
        }
        key = regHive.OpenSubKey(regKey,true);
        key.SetValue(regName, (string)regValue);
    }
    SetRegistryKey(RegistryHive.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", 1)
