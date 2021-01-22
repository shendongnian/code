    [StructLayout(LayoutKind.Sequential)]
    public struct SC_HANDLE__
    {
        public int unused;
    }
    [Flags]
    public enum SERVICE_CONTROL : uint
    {
        STOP = 0x00000001,
        PAUSE = 0x00000002,
        CONTINUE = 0x00000003,
        INTERROGATE = 0x00000004,
        SHUTDOWN = 0x00000005,
        PARAMCHANGE = 0x00000006,
        NETBINDADD = 0x00000007,
        NETBINDREMOVE = 0x00000008,
        NETBINDENABLE = 0x00000009,
        NETBINDDISABLE = 0x0000000A,
        DEVICEEVENT = 0x0000000B,
        HARDWAREPROFILECHANGE = 0x0000000C,
        POWEREVENT = 0x0000000D,
        SESSIONCHANGE = 0x0000000E
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_STATUS
    {
        /// DWORD->unsigned int
        public uint dwServiceType;
        /// DWORD->unsigned int
        public uint dwCurrentState;
        /// DWORD->unsigned int
        public uint dwControlsAccepted;
        /// DWORD->unsigned int
        public uint dwWin32ExitCode;
        /// DWORD->unsigned int
        public uint dwServiceSpecificExitCode;
        /// DWORD->unsigned int
        public uint dwCheckPoint;
        /// DWORD->unsigned int
        public uint dwWaitHint;
    }
    public class NativeMethods
    {
        public const int SC_MANAGER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED
                    | (SC_MANAGER_CONNECT
                    | (SC_MANAGER_CREATE_SERVICE
                    | (SC_MANAGER_ENUMERATE_SERVICE
                    | (SC_MANAGER_LOCK
                    | (SC_MANAGER_QUERY_LOCK_STATUS | SC_MANAGER_MODIFY_BOOT_CONFIG))))));
        /// STANDARD_RIGHTS_REQUIRED -> (0x000F0000L)
        public const int STANDARD_RIGHTS_REQUIRED = 983040;
        /// SC_MANAGER_CONNECT -> 0x0001
        public const int SC_MANAGER_CONNECT = 1;
        /// SC_MANAGER_CREATE_SERVICE -> 0x0002
        public const int SC_MANAGER_CREATE_SERVICE = 2;
        /// SC_MANAGER_ENUMERATE_SERVICE -> 0x0004
        public const int SC_MANAGER_ENUMERATE_SERVICE = 4;
        /// SC_MANAGER_LOCK -> 0x0008
        public const int SC_MANAGER_LOCK = 8;
        /// SC_MANAGER_QUERY_LOCK_STATUS -> 0x0010
        public const int SC_MANAGER_QUERY_LOCK_STATUS = 16;
        /// SC_MANAGER_MODIFY_BOOT_CONFIG -> 0x0020
        public const int SC_MANAGER_MODIFY_BOOT_CONFIG = 32;
        /// SERVICE_CONTROL_STOP -> 0x00000001
        public const int SERVICE_CONTROL_STOP = 1;
        /// SERVICE_QUERY_STATUS -> 0x0004
        public const int SERVICE_QUERY_STATUS = 4;
        public const int GENERIC_EXECUTE = 536870912;
        /// SERVICE_RUNNING -> 0x00000004
        public const int SERVICE_RUNNING = 4;
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW")]
        public static extern IntPtr OpenSCManagerW(
            [In()] [MarshalAs(UnmanagedType.LPWStr)] string lpMachineName,
            [In()] [MarshalAs(UnmanagedType.LPWStr)] string lpDatabaseName,
            uint dwDesiredAccess);
        
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ControlService(IntPtr hService, SERVICE_CONTROL dwControl, ref SERVICE_STATUS lpServiceStatus);
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseServiceHandle(IntPtr hSCObject);
        [DllImport("advapi32.dll", EntryPoint = "QueryServiceStatus", CharSet = CharSet.Auto)]
        public static extern bool QueryServiceStatus(IntPtr hService, ref SERVICE_STATUS dwServiceStatus);
        [SecurityCritical]
        [HandleProcessCorruptedStateExceptions]
        public static void ServiceStop()
        {
            IntPtr manager = IntPtr.Zero;
            IntPtr service = IntPtr.Zero;
            SERVICE_STATUS status = new SERVICE_STATUS();
            if ((manager = OpenSCManagerW(null, null, SC_MANAGER_ALL_ACCESS)) != IntPtr.Zero)
            {
                if ((service = OpenService(manager, Resources.ServiceName, SC_MANAGER_ALL_ACCESS)) != IntPtr.Zero)
                {
                    QueryServiceStatus(service, ref status);
                }
                if (status.dwCurrentState == SERVICE_RUNNING)
                {
                    int i = 0;
                    //not the best way, but WaitStatus didnt work correctly. 
                    while (i++ < 10 && status.dwCurrentState != SERVICE_CONTROL_STOP)
                    {
                        ControlService(service, SERVICE_CONTROL.STOP, ref status);
                        QueryServiceStatus(service, ref status);
                        Thread.Sleep(200);
                    }
                   
                }
            }
            if (manager != IntPtr.Zero)
            {
                var b = CloseServiceHandle(manager);
            }
            if (service != IntPtr.Zero)
            {
                var b = CloseServiceHandle(service);
            }
        }
    }
