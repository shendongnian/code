    [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi)]
    static extern void GetSystemTimePreciseAsFileTime(out long filetime);
    public DateTimeOffset GetNow()
    {
        long fileTime;
        GetSystemTimePreciseAsFileTime(out fileTime);
        return DateTimeOffset.FromFileTime(fileTime);
    }
