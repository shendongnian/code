    class Program
    {
        #region Interop
        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public UInt32 LowPart;
            public Int32 HighPart;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public UInt32 Attributes;
        }
        public struct TOKEN_PRIVILEGES
        {
            public UInt32 PrivilegeCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public LUID_AND_ATTRIBUTES[] Privileges;
        }
        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            MaxTokenInfoClass
        }
        [Flags]
        enum CreationFlags : uint
        {
            CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
            CREATE_DEFAULT_ERROR_MODE = 0x04000000,
            CREATE_NEW_CONSOLE = 0x00000010,
            CREATE_NEW_PROCESS_GROUP = 0x00000200,
            CREATE_NO_WINDOW = 0x08000000,
            CREATE_PROTECTED_PROCESS = 0x00040000,
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
            CREATE_SEPARATE_WOW_VDM = 0x00001000,
            CREATE_SUSPENDED = 0x00000004,
            CREATE_UNICODE_ENVIRONMENT = 0x00000400,
            DEBUG_ONLY_THIS_PROCESS = 0x00000002,
            DEBUG_PROCESS = 0x00000001,
            DETACHED_PROCESS = 0x00000008,
            EXTENDED_STARTUPINFO_PRESENT = 0x00080000
        }
        public enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }
        [Flags]
        enum LogonFlags
        {
            LOGON_NETCREDENTIALS_ONLY = 2,
            LOGON_WITH_PROFILE = 1
        }
        
        enum LOGON_TYPE
        {
            LOGON32_LOGON_INTERACTIVE = 2,
            LOGON32_LOGON_NETWORK,
            LOGON32_LOGON_BATCH,
            LOGON32_LOGON_SERVICE,
            LOGON32_LOGON_UNLOCK = 7,
            LOGON32_LOGON_NETWORK_CLEARTEXT,
            LOGON32_LOGON_NEW_CREDENTIALS
        }
        enum LOGON_PROVIDER
        {
            LOGON32_PROVIDER_DEFAULT,
            LOGON32_PROVIDER_WINNT35,
            LOGON32_PROVIDER_WINNT40,
            LOGON32_PROVIDER_WINNT50
        }
        #region _SECURITY_ATTRIBUTES
        //typedef struct _SECURITY_ATTRIBUTES {  
        //    DWORD nLength;  
        //    LPVOID lpSecurityDescriptor;  
        //    BOOL bInheritHandle;
        //} SECURITY_ATTRIBUTES,  *PSECURITY_ATTRIBUTES,  *LPSECURITY_ATTRIBUTES;
        #endregion
        struct SECURITY_ATTRIBUTES
        {
            public uint Length;
            public IntPtr SecurityDescriptor;
            public bool InheritHandle;
        }
        [Flags] enum SECURITY_INFORMATION : uint
        {
            OWNER_SECURITY_INFORMATION        = 0x00000001,
            GROUP_SECURITY_INFORMATION        = 0x00000002,
            DACL_SECURITY_INFORMATION         = 0x00000004,
            SACL_SECURITY_INFORMATION         = 0x00000008,
            UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000,
            UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,
            PROTECTED_SACL_SECURITY_INFORMATION   = 0x40000000,
            PROTECTED_DACL_SECURITY_INFORMATION   = 0x80000000
        }
        #region _SECURITY_DESCRIPTOR
        //typedef struct _SECURITY_DESCRIPTOR {
        //  UCHAR  Revision;
        //  UCHAR  Sbz1;
        //  SECURITY_DESCRIPTOR_CONTROL  Control;
        //  PSID  Owner;
        //  PSID  Group;
        //  PACL  Sacl;
        //  PACL  Dacl;
        //} SECURITY_DESCRIPTOR, *PISECURITY_DESCRIPTOR;
        #endregion
        [StructLayoutAttribute(LayoutKind.Sequential)]
        struct SECURITY_DESCRIPTOR
        {
            public byte revision;
            public byte size;
            public short control; // public SECURITY_DESCRIPTOR_CONTROL control;
            public IntPtr owner;
            public IntPtr group;
            public IntPtr sacl;
            public IntPtr dacl;
        }
        #region _STARTUPINFO
        //typedef struct _STARTUPINFO {  
        //    DWORD cb;  
        //    LPTSTR lpReserved;  
        //    LPTSTR lpDesktop;  
        //    LPTSTR lpTitle;  
        //    DWORD dwX;  
        //    DWORD dwY;  
        //    DWORD dwXSize;  
        //    DWORD dwYSize;  
        //    DWORD dwXCountChars;  
        //    DWORD dwYCountChars;  
        //    DWORD dwFillAttribute;  
        //    DWORD dwFlags;  
        //    WORD wShowWindow;  
        //    WORD cbReserved2;  
        //    LPBYTE lpReserved2;  
        //    HANDLE hStdInput;  
        //    HANDLE hStdOutput;  
        //    HANDLE hStdError; 
        //} STARTUPINFO,  *LPSTARTUPINFO;
        #endregion
        struct STARTUPINFO
        {
            public uint cb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string Reserved;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string Desktop;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string Title;
            public uint X;
            public uint Y;
            public uint XSize;
            public uint YSize;
            public uint XCountChars;
            public uint YCountChars;
            public uint FillAttribute;
            public uint Flags;
            public ushort ShowWindow;
            public ushort Reserverd2;
            public byte bReserverd2;
            public IntPtr StdInput;
            public IntPtr StdOutput;
            public IntPtr StdError;
        }
        #region _PROCESS_INFORMATION
        //typedef struct _PROCESS_INFORMATION {  
        //  HANDLE hProcess;  
        //  HANDLE hThread;  
        //  DWORD dwProcessId;  
        //  DWORD dwThreadId; } 
        //  PROCESS_INFORMATION,  *LPPROCESS_INFORMATION;
        #endregion
        [StructLayout(LayoutKind.Sequential)]
        struct PROCESS_INFORMATION
        {
            public IntPtr Process;
            public IntPtr Thread;
            public uint ProcessId;
            public uint ThreadId;
        }
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool InitializeSecurityDescriptor(IntPtr pSecurityDescriptor, uint dwRevision);
        const uint SECURITY_DESCRIPTOR_REVISION = 1;
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool SetSecurityDescriptorDacl(ref SECURITY_DESCRIPTOR sd, bool daclPresent, IntPtr dacl, bool daclDefaulted);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern static bool DuplicateTokenEx(
            IntPtr hExistingToken,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpTokenAttributes,
            SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            TOKEN_TYPE TokenType,
            out IntPtr phNewToken);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            out IntPtr phToken
            );
        #region GetTokenInformation
        //BOOL WINAPI GetTokenInformation(
        //  __in       HANDLE TokenHandle,
        //  __in       TOKEN_INFORMATION_CLASS TokenInformationClass,
        //  __out_opt  LPVOID TokenInformation,
        //  __in       DWORD TokenInformationLength,
        //  __out      PDWORD ReturnLength
        //);
        #endregion
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(
            IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            int TokenInformationLength,
            out int ReturnLength
            );
        #region CreateProcessAsUser
        //        BOOL WINAPI CreateProcessAsUser(
        //  __in_opt     HANDLE hToken,
        //  __in_opt     LPCTSTR lpApplicationName,
        //  __inout_opt  LPTSTR lpCommandLine,
        //  __in_opt     LPSECURITY_ATTRIBUTES lpProcessAttributes,
        //  __in_opt     LPSECURITY_ATTRIBUTES lpThreadAttributes,
        //  __in         BOOL bInheritHandles,
        //  __in         DWORD dwCreationFlags,
        //  __in_opt     LPVOID lpEnvironment,
        //  __in_opt     LPCTSTR lpCurrentDirectory,
        //  __in         LPSTARTUPINFO lpStartupInfo,
        //  __out        LPPROCESS_INFORMATION lpProcessInformation);
        #endregion
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool CreateProcessAsUser(
            IntPtr Token, 
            [MarshalAs(UnmanagedType.LPTStr)] string ApplicationName,
            [MarshalAs(UnmanagedType.LPTStr)] string CommandLine,
            ref SECURITY_ATTRIBUTES ProcessAttributes, 
            ref SECURITY_ATTRIBUTES ThreadAttributes, 
            bool InheritHandles,
            uint CreationFlags, 
            IntPtr Environment, 
            [MarshalAs(UnmanagedType.LPTStr)] string CurrentDirectory, 
            ref STARTUPINFO StartupInfo, 
            out PROCESS_INFORMATION ProcessInformation);
        #region CloseHandle
        //BOOL WINAPI CloseHandle(
        //      __in          HANDLE hObject
        //        );
        #endregion
        [DllImport("Kernel32.dll")]
        extern static int CloseHandle(IntPtr handle);
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }
        //static internal const int TOKEN_QUERY = 0x00000008;
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        //static internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_DUPLICATE = 0x0002;
        internal const int TOKEN_ASSIGN_PRIMARY = 0x0001;
        #endregion
        [STAThread]
        static void Main(string[] args)
        {
            string username, domain, password, applicationName;
            username = args[2];
            domain = args[1];
            password = args[3];
            applicationName = @args[0];
            IntPtr token = IntPtr.Zero;
            IntPtr primaryToken = IntPtr.Zero;
            try
            {
                bool result = false;
                result = LogonUser(username, domain, password, (int)LOGON_TYPE.LOGON32_LOGON_NETWORK, (int)LOGON_PROVIDER.LOGON32_PROVIDER_DEFAULT, out token);
                if (!result)
                {
                    int winError = Marshal.GetLastWin32Error();
                }
                string commandLine = null;
                #region security attributes
                SECURITY_ATTRIBUTES processAttributes = new SECURITY_ATTRIBUTES();
                SECURITY_DESCRIPTOR sd = new SECURITY_DESCRIPTOR();
                IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(sd));
                Marshal.StructureToPtr(sd, ptr, false);
                InitializeSecurityDescriptor(ptr, SECURITY_DESCRIPTOR_REVISION);
                sd = (SECURITY_DESCRIPTOR)Marshal.PtrToStructure(ptr, typeof(SECURITY_DESCRIPTOR));
                
                result = SetSecurityDescriptorDacl(ref sd, true, IntPtr.Zero, false);
                if (!result)
                {
                    int winError = Marshal.GetLastWin32Error();
                }
                primaryToken = new IntPtr();
                result = DuplicateTokenEx(token, 0, ref processAttributes, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenPrimary, out primaryToken);
                if (!result)
                {
                    int winError = Marshal.GetLastWin32Error();
                }
                processAttributes.SecurityDescriptor = ptr;
                processAttributes.Length = (uint)Marshal.SizeOf(sd);
                processAttributes.InheritHandle = true;
                #endregion
                SECURITY_ATTRIBUTES threadAttributes = new SECURITY_ATTRIBUTES();
                threadAttributes.SecurityDescriptor = IntPtr.Zero;
                threadAttributes.Length = 0;
                threadAttributes.InheritHandle = false;
                bool inheritHandles = true;
                //CreationFlags creationFlags = CreationFlags.CREATE_DEFAULT_ERROR_MODE;
                IntPtr environment = IntPtr.Zero;
                string currentDirectory = currdir;
                STARTUPINFO startupInfo = new STARTUPINFO();
                startupInfo.Desktop = "";
                PROCESS_INFORMATION processInformation;
                result = CreateProcessAsUser(primaryToken, applicationName, commandLine, ref processAttributes, ref threadAttributes, inheritHandles, 16, environment, currentDirectory, ref startupInfo, out processInformation);
                if (!result)
                {
                    int winError = Marshal.GetLastWin32Error();
                    File.AppendAllText(logfile, DateTime.Now.ToLongTimeString() + " " + winError + Environment.NewLine);
                }
            }
            catch
            {
                int winError = Marshal.GetLastWin32Error();
                File.AppendAllText(logfile, DateTime.Now.ToLongTimeString() + " " + winError + Environment.NewLine);
            }
            finally
            {
                if (token != IntPtr.Zero)
                {
                    int x = CloseHandle(token);
                    if (x == 0)
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    x = CloseHandle(primaryToken);
                    if (x == 0)
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
        }
