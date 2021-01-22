    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class Impersonation : IDisposable
    {
            private readonly SafeTokenHandle _handle;
            private readonly WindowsImpersonationContext _context;
    
            //const int Logon32LogonNewCredentials = 9; 
            private const int Logon32LogonInteractive = 2;
    
            public Impersonation()
            {
                var settings = Settings.Instance.Whatever;
                var domain = settings.Domain;
                var username = settings.User;
                var password = settings.Password;
                var ok = LogonUser(username, domain, password, Logon32LogonInteractive, 0, out _handle);
                if (!ok)
                {
                    var errorCode = Marshal.GetLastWin32Error();
                    throw new ApplicationException(string.Format("Could not impersonate the elevated user.  LogonUser returned error code {0}.", errorCode));
                }
                _context = WindowsIdentity.Impersonate(_handle.DangerousGetHandle());
            }
            
            public void Dispose()
            {
                _context.Dispose();
                _handle.Dispose();
            }
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
    
            public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
            {
                private SafeTokenHandle()
                    : base(true) { }
    
                [DllImport("kernel32.dll")]
                [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
                [SuppressUnmanagedCodeSecurity]
                [return: MarshalAs(UnmanagedType.Bool)]
                private static extern bool CloseHandle(IntPtr handle);
    
                protected override bool ReleaseHandle()
                {
                    return CloseHandle(handle);
                }
            }
    }
