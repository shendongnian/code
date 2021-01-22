    class UserImpersonation2:IDisposable
        {
            [DllImport("advapi32.dll")]
            public static extern bool LogonUser(String lpszUserName,
                String lpszDomain,
                String lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                ref IntPtr phToken);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern bool CloseHandle(IntPtr handle);
    
            WindowsImpersonationContext wic;
            IntPtr tokenHandle;
            string _userName;
            string _domain;
            string _passWord;
    
            public UserImpersonation2(string userName, string domain, string passWord)
            {
                _userName = userName;
                _domain = domain;
                _passWord = passWord;
            }
    
            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_INTERACTIVE = 2;
    
            public bool ImpersonateValidUser()
            {
                bool returnValue = LogonUser(_userName, _domain, _passWord,
                        LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                        ref tokenHandle);
    
                Console.WriteLine("LogonUser called.");
    
                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    Console.WriteLine("LogonUser failed with error code : {0}", ret);
                    return false;
                }
    
                Console.WriteLine("Did LogonUser Succeed? " + (returnValue ? "Yes" : "No"));
                Console.WriteLine("Value of Windows NT token: " + tokenHandle);
    
                // Check the identity.
                Console.WriteLine("Before impersonation: "
                    + WindowsIdentity.GetCurrent().Name);
                // Use the token handle returned by LogonUser.
                WindowsIdentity newId = new WindowsIdentity(tokenHandle);
                wic = newId.Impersonate();
    
                // Check the identity.
                Console.WriteLine("After impersonation: "
                    + WindowsIdentity.GetCurrent().Name);
                return true;
            }
            #region IDisposable Members
            public void Dispose()
            {
                if(wic!=null)
                    wic.Undo();
                if (tokenHandle != IntPtr.Zero)
                    CloseHandle(tokenHandle);
    
            }
            #endregion
        }
