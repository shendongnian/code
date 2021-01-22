    using System;
    using System.Runtime.InteropServices;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                IntPtr token = IntPtr.Zero;
                string userPrincipalName = "userID@domain.com";
                string authority = null; // Can be null when using UPN (user principal name)
                string badPassword = "bad";
    
                int maxTries = 100;
                bool res = false;
    
                for (var i = 0; i < maxTries; i++)
                {
                    res = LogonUser(userPrincipalName, authority, badPassword, LogonSessionType.Interactive, LogonProvider.Default, out token);
                    CloseHandle(token);
                }
            }
    
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool LogonUser(
              string principal,
              string authority,
              string password,
              LogonSessionType logonType,
              LogonProvider logonProvider,
              out IntPtr token);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool CloseHandle(IntPtr handle);
            enum LogonSessionType : uint
            {
                Interactive = 2,
                Network,
                Batch,
                Service,
                NetworkCleartext = 8,
                NewCredentials
            }
    
            enum LogonProvider : uint
            {
                Default = 0, // default for platform (use this!)
                WinNT35,     // sends smoke signals to authority
                WinNT40,     // uses NTLM
                WinNT50      // negotiates Kerb or NTLM
            }
        }
    }
