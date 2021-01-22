    static string AppRegyPath = "Software\\Cheeso\\ApplicationName";
    static string rvn_Runs = "Runs";
    private Microsoft.Win32.RegistryKey _appCuKey;
    public Microsoft.Win32.RegistryKey AppCuKey
    {
        get
        {
            if (_appCuKey == null)
            {
                _appCuKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AppRegyPath, true);
                if (_appCuKey == null)
                    _appCuKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(AppRegyPath);
            }
            return _appCuKey;
        }
        set { _appCuKey = null; }
    }
    public int UpdateRunCount()
    {
        int x = (Int32)AppCuKey.GetValue(rvn_Runs, 0);
        x++;
        AppCuKey.SetValue(rvn_Runs, x);
        return x;
    }
