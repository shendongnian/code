    public sealed class WrappedImpersonationContext
    {
        public enum LogonType : int
        {
            Interactive = 2,
            Network = 3,
            Batch = 4,
            Service = 5,
            Unlock = 7,
            NetworkClearText = 8,
            NewCredentials = 9
        }
        public enum LogonProvider : int
        {
            Default = 0,  // LOGON32_PROVIDER_DEFAULT
            WinNT35 = 1,
            WinNT40 = 2,  // Use the NTLM logon provider.
            WinNT50 = 3   // Use the negotiate logon provider.
        }
        [DllImport("advapi32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain,
            String lpszPassword, LogonType dwLogonType, LogonProvider dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll")]
        public extern static bool CloseHandle(IntPtr handle);
        private string _domain, _password, _username;
        private IntPtr _token;
        private WindowsImpersonationContext _context;
        private bool disposed = false;
        private bool IsInContext
        {
            get { return _context != null; }
        }
        public WrappedImpersonationContext(string domain, string username, string password)
        {
            _domain = String.IsNullOrEmpty(domain) ? "." : domain;
            _username = username;
            _password = password;
        }
        // Changes the Windows identity of this thread. Make sure to always call Leave() at the end.
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Enter()
        {
            if (IsInContext)
                return;
            _token = IntPtr.Zero;
            bool logonSuccessfull = LogonUser(_username, _domain, _password, LogonType.NewCredentials, LogonProvider.WinNT50, ref _token);
            if (!logonSuccessfull)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            WindowsIdentity identity = new WindowsIdentity(_token);
            _context = identity.Impersonate();
            Debug.WriteLine(WindowsIdentity.GetCurrent().Name);
        }
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Leave()
        {
            if (!IsInContext)
                return;
            _context.Undo();
            if (_token != IntPtr.Zero)
            {
                CloseHandle(_token);
            }
            _context = null;
        }
    }
