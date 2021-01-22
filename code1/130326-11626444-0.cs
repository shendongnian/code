    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Security;
    using System.Security.Principal;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Text;
    
    using System.Web;
    
    // you must change the YourProgramName 
    
    namespace [YourProgramName]
    {
        public class Impersonate
        {
    
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword,
                                                int dwLogonType, int dwLogonProvider, out int phToken);
    
            [DllImport("kernel32.dll")]
            private static extern int FormatMessage(int dwFlags, string lpSource, int dwMessageId, int dwLanguageId,
                                                    StringBuilder lpBuffer, int nSize, string[] Arguments);
    
    
            private const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;
            private const int LOGON32_PROVIDER_DEFAULT = 0;
            private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
    
            private static WindowsImpersonationContext winImpersonationContext = null;
    
            public static void ImpersonateUser(string domain, string userName, string password)
            {
    
                //Benutzer einloggen
                int userToken = 0;
    
                bool loggedOn = (LogonUser(userName, domain, password, LOGON32_LOGON_NETWORK_CLEARTEXT,
                                            LOGON32_PROVIDER_DEFAULT, out userToken) != 0);
    
                if (loggedOn == false)
                {
                    int apiError = Marshal.GetLastWin32Error();
                    StringBuilder errorMessage = new StringBuilder(1024);
                    FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, null, apiError, 0, errorMessage, 1024, null);
                    throw new Exception(errorMessage.ToString());
                }
    
                WindowsIdentity identity = new WindowsIdentity((IntPtr)userToken);
                winImpersonationContext = identity.Impersonate();
    
            }
    
            public static void UndoImpersonation()
            {
                if (winImpersonationContext != null)
                {
                    winImpersonationContext.Undo();
                }
            }
    
        }
    }
