    [DllImport("libc")]
    public static extern uint getuid(); // Only used on Linux but causes no issues on Windows
    static bool RunningAsAdmin()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            using var identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        else return getuid() == 0;
    }
