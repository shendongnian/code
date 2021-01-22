    enum OS { _2000, XP, Server2003, Vista, Server2008, _7, Server2012, _8 }
    const int OS_ANYSERVER = 29;
    [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
    static extern bool IsOS(int os);
    static bool isWindowsServer = IsOS(OS_ANYSERVER);
    public static OS GetOS()
    {
        var version = Environment.OSVersion.Version;
        switch (version.Major)
        {
            case 5:
                switch (version.Minor)
                {
                    case 0:
                        return OS._2000;
                    case 1:
                        return OS.XP;
                    case 2:
                        return isWindowsServer ? OS.Server2003 : OS.XP;
                }
                break;
            case 6:
                switch (version.Minor)
                {
                    case 0:
                        return isWindowsServer ? OS.Server2008 : OS.Vista;
                    case 1:
                        return isWindowsServer ? OS.Server2008 : OS._7;
                    case 2:
                        return isWindowsServer ? OS.Server2012 : OS._8;
                }
                break;
        }
        throw new Exception("Strange OS");
    }
