    public void ConfigureWindowsRegistry()
    {
        RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64); //here you specify where exactly you want your entry
        var reg = localMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
        if (reg == null)
        {
            reg = localMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
        }
        if (reg.GetValue("EnableLinkedConnections") == null)
        {
            reg.SetValue("EnableLinkedConnections", "1", RegistryValueKind.DWord);
            MessageBox.Show(
                "Your configuration is now created,you have to restart your device to let app work perfektly");
        }
    }
