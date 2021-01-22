    // a really simple check that does not account for possible UAC-disabledness via group policy
    public static bool IsUACEnabledOS()
    {
    int majorVersion = Environment.OSVersion.Version.Major;
    int minorVersion = Environment.OSVersion.Version.Minor;
    
    return (majorVersion >= 6);
    }
