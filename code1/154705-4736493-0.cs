    using System;
    using System.Runtime.InteropServices;  // DllImport
    using System.Security.Principal; // WindowsImpersonationContext
    namespace TestApp
    {
        class Impersonator
        {
            // group type enum
            enum SECURITY_IMPERSONATION_LEVEL : int
            {
                SecurityAnonymous = 0,
                SecurityIdentification = 1,
                SecurityImpersonation = 2,
                SecurityDelegation = 3
            }
            // obtains user token
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
                int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
            // closes open handes returned by LogonUser
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            extern static bool CloseHandle(IntPtr handle);
            // creates duplicate token handle
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
                int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);
            WindowsImpersonationContext newUser;
            /// <summary>
            /// Attempts to impersonate a user.  If successful, returns 
            /// a WindowsImpersonationContext of the new users identity.
            /// </summary>
            /// <param name="sUsername">Username you want to impersonate</param>
            /// <param name="sDomain">Logon domain</param>
            /// <param name="sPassword">User's password to logon with</param></param>
            /// <returns></returns>
            public Impersonator(string sUsername, string sDomain, string sPassword)
            {
                // initialize tokens
                IntPtr pExistingTokenHandle = new IntPtr(0);
                IntPtr pDuplicateTokenHandle = new IntPtr(0);
                pExistingTokenHandle = IntPtr.Zero;
                pDuplicateTokenHandle = IntPtr.Zero;
                // if domain name was blank, assume local machine
                if (sDomain == "")
                    sDomain = System.Environment.MachineName;
                try
                {
                    const int LOGON32_PROVIDER_DEFAULT = 0;
                    // create token
                    // const int LOGON32_LOGON_INTERACTIVE = 2;
                    const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
                    //const int SecurityImpersonation = 2;
                    // get handle to token
                    bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
                        LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);
                    // did impersonation fail?
                    if (false == bImpersonated)
                    {
                        int nErrorCode = Marshal.GetLastWin32Error();
                        // show the reason why LogonUser failed
                        throw new ApplicationException("LogonUser() failed with error code: " + nErrorCode);
                    }
                    bool bRetVal = DuplicateToken(pExistingTokenHandle, (int)SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, ref pDuplicateTokenHandle);
                    // did DuplicateToken fail?
                    if (false == bRetVal)
                    {
                        int nErrorCode = Marshal.GetLastWin32Error();
                        CloseHandle(pExistingTokenHandle); // close existing handle
                        // show the reason why DuplicateToken failed
                        throw new ApplicationException("DuplicateToken() failed with error code: " + nErrorCode);
                    }
                    else
                    {
                        // create new identity using new primary token
                        WindowsIdentity newId = new WindowsIdentity(pDuplicateTokenHandle);
                        WindowsImpersonationContext impersonatedUser = newId.Impersonate();
                        newUser = impersonatedUser;
                    }
                }
                finally
                {
                    // close handle(s)
                    if (pExistingTokenHandle != IntPtr.Zero)
                        CloseHandle(pExistingTokenHandle);
                    if (pDuplicateTokenHandle != IntPtr.Zero)
                        CloseHandle(pDuplicateTokenHandle);
                }
            }
            public void Undo()
            {
                newUser.Undo();
            }
        }
    }
