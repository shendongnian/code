    RegistryKey Copen = Registry.LocalMachine.OpenSubKey(@"Software\ComodoGroup\CDI\1\");
    if(Copen != null)
    {
        object o = Copen.GetValue("InstallProductPath");
        if(o != null)
        {
             System.Diagnostics.Process.Start(IO.Path.Combine(o.ToString(), "cfp.exe"));
        }
        else
            MessageBox.Show("Value not found");
    }
    else
        MessageBox.Show("Failed to open key");
