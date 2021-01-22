    using System;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Runtime.InteropServices;
    namespace User
    {
        public static class UserValidation
        {
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool LogonUser(string principal, string authority, string password, LogonTypes logonType, LogonProviders logonProvider, out IntPtr token);
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool CloseHandle(IntPtr handle);
            enum LogonProviders : uint
            {
                Default = 0, // default for platform (use this!)
                WinNT35,     // sends smoke signals to authority
                WinNT40,     // uses NTLM
                WinNT50      // negotiates Kerb or NTLM
            }
            enum LogonTypes : uint
            {
                Interactive = 2,
                Network = 3,
                Batch = 4,
                Service = 5,
                Unlock = 7,
                NetworkCleartext = 8,
                NewCredentials = 9
            }
            public  const int ERROR_PASSWORD_MUST_CHANGE = 1907;
            public  const int ERROR_LOGON_FAILURE = 1326;
            public  const int ERROR_ACCOUNT_RESTRICTION = 1327;
            public  const int ERROR_ACCOUNT_DISABLED = 1331;
            public  const int ERROR_INVALID_LOGON_HOURS = 1328;
            public  const int ERROR_NO_LOGON_SERVERS = 1311;
            public  const int ERROR_INVALID_WORKSTATION = 1329;
            public  const int ERROR_ACCOUNT_LOCKED_OUT = 1909;      //It gives this error if the account is locked, REGARDLESS OF WHETHER VALID CREDENTIALS WERE PROVIDED!!!
            public  const int ERROR_ACCOUNT_EXPIRED = 1793;
            public  const int ERROR_PASSWORD_EXPIRED = 1330;
            public static int CheckUserLogon(string username, string password, string domain_fqdn)
            {
                int errorCode = 0;
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain_fqdn, "ADMIN_USER", "PASSWORD"))
                {
                    if (!pc.ValidateCredentials(username, password))
                    {
                        IntPtr token = new IntPtr();
                        try
                        {
                            if (!LogonUser(username, domain_fqdn, password, LogonTypes.Network, LogonProviders.Default, out token))
                            {
                                errorCode = Marshal.GetLastWin32Error();
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            CloseHandle(token);
                        }
                    }
                }
                return errorCode;
            }
    	}
