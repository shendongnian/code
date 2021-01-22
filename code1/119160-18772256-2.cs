    using (var view32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                                                RegistryView.Registry32))
    {
      using (var clsid32 = view32.OpenSubKey(@"Software\Classes\CLSID\", false))
      {
        // actually accessing Wow6432Node 
      }
    }
