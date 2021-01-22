    class OS
    {
        public static bool IsWindowsServer()
        {
            return OS.IsOS (OS.OS_ANYSERVER);
        }
        const int OS_ANYSERVER = 29;
        [DllImport("shlwapi.dll", SetLastError=true, EntryPoint="#437")]
        private static extern bool IsOS(int os);
    }
