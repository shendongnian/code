    public static TimeSpan GetUpTime()
    {
        return TimeSpan.FromMilliseconds(GetTickCount64());
    }
    [DllImport("kernel32")]
    extern static UInt64 GetTickCount64();
