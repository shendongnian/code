    using (var view64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                                                RegistryView.Registry64))
    {
      using (var clsid64 = view64.OpenSubKey(@"Software\Classes\CLSID\", true))
      {
        ....
      }
    }
