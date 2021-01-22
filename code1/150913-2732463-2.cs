    static bool IsWinXPOrHigher
    {
        OperatingSystem OS = Environment.OSVersion;
        return (OS.Platform == PlatformID.Win32NT) && ((OS.Version.Major > 5) || ((OS.Version.Major == 5) && (OS.Version.Minor >= 1)));
    }
    
    static bool IsWinVistaOrHigher
    {
        OperatingSystem OS = Environment.OSVersion;
        return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
    }
