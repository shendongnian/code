       	[DllImport("advapi32.DLL", SetLastError = true)]
            public static extern int LogonUser(string lpszUsername, string lpszDomain,
                string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
            [DllImport("advapi32.DLL")]
            public static extern bool ImpersonateLoggedOnUser(IntPtr hToken); //handle to token for logged-on user
            [DllImport("advapi32.DLL")]
            public static extern bool RevertToSelf();
            [DllImport("kernel32.dll")]
            public extern static bool CloseHandle(IntPtr hToken);
    
            enum LogonType
            {
                Interactive = 2,
                Network = 3,
                Batch = 4,
                Service = 5,
                Unlock = 7,
                NetworkClearText = 8,
                NewCredentials = 9
            }
    
            enum LogonProvider
            {
                Default = 0,
                WinNT35 = 1,
                WinNT40 = 2,
                WinNT50 = 3
            }
    
    int valid = LogonUser(ssUsername,
                                ssDomain,
                                ssPassword,
                                (int)LogonType.Interactive,
                                (int)LogonProvider.WinNT50,
                                out admin_token);
                    if (valid != 0)
                    {
                        using (WindowsImpersonationContext context = WindowsIdentity.Impersonate(admin_token))
                        {
                            CloseHandle(admin_token);
                            FileInfo fi = new FileInfo(ssPath);
                            //Destination Directory does not exist ?
                            if (!Directory.Exists(Path.GetDirectoryName(ssDestinationDirectoryPath)))
                                Directory.CreateDirectory(Path.GetDirectoryName(
                                ssDestinationDirectoryPath));
                            fi.CopyTo(ssDestinationDirectoryPath);
                            fi.Delete();
                        }
                    }
