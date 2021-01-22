    static bool IsWinXP
    {
        OperatingSystem OS = Environment.OSVersion;
        return (OS.Platform == PlatformID.Win32NT) && ((OS.Version.Major > 5) || ((OS.Version.Major == 5) && (OS.Version.Minor == 1)));
    }
    
    static bool IsWinVista
    {
        OperatingSystem OS = Environment.OSVersion;
        return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
    }
