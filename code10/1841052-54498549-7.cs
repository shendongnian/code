    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetPhysicallyInstalledSystemMemory(out ulong MemKilobytes);
    public static ulong WinAPIGetTotalPhysicalMemory()
    {
        ulong totalMemory = 0UL;
        GetPhysicallyInstalledSystemMemory(out totalMemory);
        return totalMemory * 1024;
    }
