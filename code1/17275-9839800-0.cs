    public static bool IsWinXPOrHigher(this OperatingSystem OS)
    {
      return (OS.Platform == PlatformID.Win32NT)
        && ((OS.Version.Major > 5) || ((OS.Version.Major == 5) && (OS.Version.Minor >= 1)));
    }
    public static bool IsWinVistaOrHigher(this OperatingSystem OS)
    {
      return (OS.Platform == PlatformID.Win32NT)
        && (OS.Version.Major >= 6);
    }
    public static bool IsWin7OrHigher(this OperatingSystem OS)
    {
      return (OS.Platform == PlatformID.Win32NT)
        && ((OS.Version.Major > 6) || ((OS.Version.Major == 6) && (OS.Version.Minor >= 1)));
    }
    public static bool IsWin8OrHigher(this OperatingSystem OS)
    {
      return (OS.Platform == PlatformID.Win32NT)
        && ((OS.Version.Major > 6) || ((OS.Version.Major == 6) && (OS.Version.Minor >= 2)));
    }
