    [DllImport("powrprof.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
    public static bool Hibernate()
    {
        return SetSuspendState(true, false, false);
    }
    public static bool Sleep()
    {
        return SetSuspendState(false, false, false);
    }
