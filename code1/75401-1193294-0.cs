    class UserImpersonation:IDisposable
        {       
            [DllImport("advapi32.dll")]
                public static extern int LogonUser(String lpszUserName,
                    String lpszDomain,
                    String lpszPassword,
                    int dwLogonType,
                    int dwLogonProvider,
                    ref IntPtr phToken);
    
                [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern int DuplicateToken(IntPtr hToken,
                    int impersonationLevel,
                    ref IntPtr hNewToken);
    
                [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern bool RevertToSelf();
    
                [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
                public static extern bool CloseHandle(IntPtr handle);
    
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;
    
                WindowsImpersonationContext wic;
                string _userName;
                string _domain;
                string _passWord;
                public UserImpersonation(string userName, string domain, string passWord)
                {
                    _userName = userName;
                    _domain = domain;
                    _passWord = passWord;
                }
                public bool ImpersonateValidUser()
                {
                    WindowsIdentity wi;
                    IntPtr token = IntPtr.Zero;
                    IntPtr tokenDuplicate = IntPtr.Zero;
    
                    if (RevertToSelf())
                    {
                        if (LogonUser(_userName, _domain, _passWord, LOGON32_LOGON_INTERACTIVE,
                            LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                        {
                            if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                            {
                                wi = new WindowsIdentity(tokenDuplicate);
                                wic = wi.Impersonate();
                                if (wic != null)
                                {
                                    CloseHandle(token);
                                    CloseHandle(tokenDuplicate);
                                    return true;
                                }
                            }
                        }
                    }
                    if (token != IntPtr.Zero)
                        CloseHandle(token);
                    if (tokenDuplicate != IntPtr.Zero)
                        CloseHandle(tokenDuplicate);
                    return false;
                }
    
            #region IDisposable Members
                public void Dispose()
                {
                    wic.Dispose();
                    RevertToSelf();
    
                }
                #endregion
        }
