    void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
    {
        try
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("System", true); //Opens the System hive with writting permissions set to true
            key = key.CreateSubKey("CurrentControlSet"); //CreateSubKey opens if subkey exists, otherwise it will create that subkey
            key = key.CreateSubKey("services");
            key = key.CreateSubKey(serviceInstaller1.ServiceName);
            key.SetValue("DelayedAutostart", 1, RegistryValueKind.DWord);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
