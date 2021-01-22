    [DllImport("kernel32.dll")]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
    public static bool IsDllLoaded(string path)
    {
        return GetModuleHandle(path) != IntPtr.Zero;
    }
