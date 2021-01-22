    public void Foo()
    {
       foreach (string s in Microsoft.Win32.Registry.CurrentUser.GetSubKeyNames())
       {
          Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(s);
          // check here for the dll value and exit if found
          // recurse down the tree...
       }
    }
