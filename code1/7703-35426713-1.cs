    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    
    
    /// <summary>
    /// Object to change the user authticated
    /// </summary>
    public class UserImpersonation : IDisposable
    {
        /// <summary>
        /// Logon method (check athetification) from advapi32.dll
        /// </summary>
        /// <param name="lpszUserName"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll")]
        private static extern bool LogonUser(String lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);
    
        /// <summary>
        /// Close
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);
    
        private WindowsImpersonationContext _windowsImpersonationContext;
        private IntPtr _tokenHandle;
        private string _userName;
        private string _domain;
        private string _passWord;
    
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_LOGON_INTERACTIVE = 2;
    
        /// <summary>
        /// Initialize a UserImpersonation
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="domain"></param>
        /// <param name="passWord"></param>
        public UserImpersonation(string userName, string domain, string passWord)
        {
            _userName = userName;
            _domain = domain;
            _passWord = passWord;
        }
    
        /// <summary>
        /// Valiate the user inforamtion
        /// </summary>
        /// <returns></returns>
        public bool ImpersonateValidUser()
        {
            bool returnValue = LogonUser(_userName, _domain, _passWord,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                    ref _tokenHandle);
    
            if (false == returnValue)
            {
                return false;
            }
    
            WindowsIdentity newId = new WindowsIdentity(_tokenHandle);
            _windowsImpersonationContext = newId.Impersonate();
            return true;
        }
    
        #region IDisposable Members
    
        /// <summary>
        /// Dispose the UserImpersonation connection
        /// </summary>
        public void Dispose()
        {
            if (_windowsImpersonationContext != null)
                _windowsImpersonationContext.Undo();
            if (_tokenHandle != IntPtr.Zero)
                CloseHandle(_tokenHandle);
        }
    
        #endregion
    }
