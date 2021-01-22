        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CreateProcess(
            string lpApplicationName,
            StringBuilder lpCommandLine,
            SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes,
            bool bInheritHandles,
            CreateProcessFlags dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            STARTUPINFO lpStartupInfo, /// Required
            PROCESS_INFORMATION lpProcessInformation //Returns information about the created process
            );
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/aa379560(v=VS.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class SECURITY_ATTRIBUTES
    {
        public uint nLength;
        public IntPtr lpSecurityDescriptor;
        [MarshalAs(UnmanagedType.Bool)] public bool bInheritHandle;
    }
