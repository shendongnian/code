    using Microsoft.Win32;
    public RegistryKey AppCuKey
    {
        get
        {
            return Registry.CurrentUser.OpenSubKey(AppRegyPath, true)
                ?? Registry.CurrentUser.CreateSubKey(AppRegyPath);
        }
    }
