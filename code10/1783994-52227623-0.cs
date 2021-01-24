    public static class ImpersonationContext
            {
    
            private const int LOGON32_LOGON_INTERACTIVE = 2;
            private const int LOGON32_PROVIDER_DEFAULT = 0;
    
            static WindowsImpersonationContext impersonationContext;
    
            [DllImport("advapi32.dll")]
            public static extern int LogonUserA(String lpszUserName,
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
    
    
            public static bool ImpersonateUser(String userName, String domain, String password)
                {
                WindowsIdentity tempWindowsIdentity;
                IntPtr token = IntPtr.Zero;
                IntPtr tokenDuplicate = IntPtr.Zero;
    
                if (RevertToSelf())
                    {
                    if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
                        LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                        {
                        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                            {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                            impersonationContext = tempWindowsIdentity.Impersonate();
                            if (impersonationContext != null)
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
    
    
            // MADE CHANGE HERE TO IMPERSONATION TO CHECK FOR NULL BEFORE PERFORMING ANY METHOD...WAS CAUSING PROBLEMS
            public static void UndoImpersonation()
                {
                if (impersonationContext != null)
                    {
    
                    impersonationContext.Undo();
                    }
                }
    
    
            }
