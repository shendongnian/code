        [DllImport("advapi32.dll")]
        private static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        /// <summary>
        /// Used for logging on the domain
        /// </summary>
        public enum LogonProvider
        {
            /// <summary>
            /// 
            /// </summary>
            LOGON32_PROVIDER_DEFAULT = 0,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_PROVIDER_WINNT35 = 1,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_PROVIDER_WINNT40 = 2,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_PROVIDER_WINNT50 = 3
        };
        /// <summary>
        /// Used for logging on across the domain
        /// </summary>
        public enum LogonType
        {
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_INTERACTIVE = 2,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_NETWORK = 3,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_BATCH = 4,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_SERVICE = 5,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_UNLOCK = 6,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
            /// <summary>
            /// 
            /// </summary>
            LOGON32_LOGON_NEW_CREDENTIALS = 9
        }
     IntPtr token = new IntPtr();
     LogonUser(<username>, <domain>, <password>, (int)LogonType.LOGON32_LOGON_NEW_CREDENTIALS, (int)LogonProvider.LOGON32_PROVIDER_WINNT50, ref token);
     WindowsIdentity w = new WindowsIdentity(token);
     w.Impersonate();
