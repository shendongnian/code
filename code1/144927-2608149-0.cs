     #region Constants
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
     #endregion
    public WindowsImpersonationContext impersonationContext;
    #region Win32 API
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LogonUserA(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int DuplicateToken(IntPtr ExistingTokenHandle, int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool RevertToSelf();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern long CloseHandle(IntPtr handle);
        #endregion
    
    public bool Impersonate(string userName, string domain, string password)
        {
            try
            {
                bool functionReturnValue = false;
                WindowsIdentity tempWindowsIdentity = default(WindowsIdentity);
                IntPtr token = IntPtr.Zero;
                IntPtr tokenDuplicate = IntPtr.Zero;
                functionReturnValue = false;
                if (RevertToSelf())
                {
                    if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                    {
                        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                        {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                            impersonationContext = tempWindowsIdentity.Impersonate();
                            if ((impersonationContext != null))
                            {
                                functionReturnValue = true;
                            }
                        }
                    }
                }
                if (!tokenDuplicate.Equals(IntPtr.Zero))
                {
                    CloseHandle(tokenDuplicate);
                }
                if (!token.Equals(IntPtr.Zero))
                {
                    CloseHandle(token);
                }
                return functionReturnValue;
            }
            catch (Exception ex)
            {
                SQMSLog.WriteLogEntry(ex.Message, "SYSTEM");
                return false;
            }
        }
    
    public void UndoImpersonate()
        {
            impersonationContext.Undo();
        }
