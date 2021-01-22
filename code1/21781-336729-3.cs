    bool is64BitProcess = (IntPtr.Size == 8);
    bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();
    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWow64Process(
        [In] IntPtr hProcess,
        [Out] out bool wow64Process
    );
    
    public static bool InternalCheckIsWow64()
    {
        if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
            Environment.OSVersion.Version.Major >= 6)
        {
            using (Process p = Process.GetCurrentProcess())
            {
                bool retVal;
                if (!IsWow64Process(p.Handle, out retVal))
                {
                    return false;
                }
                return retVal;
            }
        }
        else
        {
            return false;
        }
    }
