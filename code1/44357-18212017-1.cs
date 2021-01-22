    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);
    
            public static bool Is64Bit()
            {
                bool retVal;
    
                IsWow64Process(Process.GetCurrentProcess().Handle, out retVal);
    
                return retVal;
            }
