    private void GetSubKeys(RegistryKey SubKey)
    {
        foreach(string sub in SubKey.GetSubKeyNames())
        {
          MessageBox.Show(sub);
          RegistryKey local = Registry.Users;
          local = SubKey.OpenSubKey(sub,true);
          GetSubKeys(local); // By recalling itselfit makes sure it get all the subkey names
        }
    }
    //This is how we call the recursive function GetSubKeys
    RegistryKey OurKey = Registry.Users;
    OurKey = OurKey.OpenSubKey(@".DEFAULT\test",true);
    GetSubKeys(OurKey);
