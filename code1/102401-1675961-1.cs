    try
    {
        RegistryKey regKey = Registry.LocalMachine;
        regKey = regKey.OpenSubKey(@"Software\Application\");
        if (regKey != null)
        {
            return regKey.GetValue("KEY NAME").ToString();
        }
        else
        {
            return null;
        }
    }
    catch (Exception ex)
    {
      return null;
    }
