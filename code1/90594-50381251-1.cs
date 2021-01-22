    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Whater\The\Key"))
    {
      if (key != null)
      {
        foreach (string ValueOfName in key.GetValueNames())
        {
          try
          {
             bool Value = bool.Parse((string)key.GetValue(ValueOfName));
          }
          catch (Exception ex) {}
        }
     }
    }
