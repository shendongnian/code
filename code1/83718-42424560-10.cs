    using System;
    using System.Data;
    using System.Configuration;
    using System.Security.Permissions;
    using System.Security.Principal;
    using System.Runtime.InteropServices;
    [assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode = true)]
    [assembly: PermissionSetAttribute(SecurityAction.RequestMinimum, Name = "FullTrust")]
    public class Impersonation
    {
        [DllImport("advapi32.dll", EntryPoint = "LogonUser")]
        public static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
            int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        // Declare the Logon Types as constants
        const int LOGON32_LOGON_INTERACTIVE = 2;
        const int LOGON32_LOGON_NETWORK = 3;
        const int LOGON32_LOGON_BATCH = 4;
        const int LOGON32_LOGON_SERVICE = 5;
        const int LOGON32_LOGON_UNLOCK = 7;
        const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8; // Win2K or higher   
        const int LOGON32_LOGON_NEW_CREDENTIALS = 9; // Win2K or higher
        // Declare the Logon Providers as constants
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_PROVIDER_WINNT50 = 3;
        const int LOGON32_PROVIDER_WINNT40 = 2;
        const int LOGON32_PROVIDER_WINNT35 = 1;
        // Declare the Impersonation Levels as constants
        const int SecurityAnonymous = 0;
        const int SecurityIdentification = 1;
        const int SecurityImpersonation = 2;
        const int SecurityDelegation = 3;
        private static WindowsIdentity newId;
        private static IntPtr tokenHandle = new IntPtr(0);
        private static IntPtr dupeTokenHandle = new IntPtr(0);
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public static WindowsImpersonationContext doImpersonation(string svcUserName, string domainName, string password)
        {
            // Initialize tokens
            tokenHandle = IntPtr.Zero;
            dupeTokenHandle = IntPtr.Zero;
   
            // Call LogonUser to obtain a handle to an access token
            bool returnValue = LogonUser(svcUserName, domainName, password,
            LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_WINNT50, ref tokenHandle);
            if (returnValue == false)
            {
                int ret = Marshal.GetLastWin32Error();
                //Check for errors
                if (ret != NO_ERROR)
                    throw new Exception("LogonUser failed with error code : " + GetError(ret));
            }
            bool retVal = DuplicateToken(tokenHandle, SecurityImpersonation, ref dupeTokenHandle);
            if (retVal == false)
            {
                CloseHandle(tokenHandle);
                throw new Exception("Exception thrown in trying to duplicate token.");
            }
            else
            {
                // Begin Impersonation
                bool bRetVal = DuplicateToken(tokenHandle,
                (int)SecurityImpersonation, ref dupeTokenHandle);
                newId = new WindowsIdentity(dupeTokenHandle);
                WindowsImpersonationContext impersonatedUser = newId.Impersonate();
                return impersonatedUser;
            }
        }
        public static void endImpersonation()
        {
            if (dupeTokenHandle != IntPtr.Zero)
                CloseHandle(dupeTokenHandle);
            if (tokenHandle != IntPtr.Zero)
                CloseHandle(tokenHandle);
        }
        public static WindowsImpersonationContext getWic(string userNameStringFromTextbox, string password)
        {
            try
            {
                // Establish impersonation
                string svcUser = userNameStringFromTextbox;
                string[] arrUser = new string[2];
                arrUser = svcUser.Split('\\');
                string domain = arrUser[0];
                string svcUserName = arrUser[1];
                // Get Password:  Convert from Base-64 String to decrypted string            
                //string keyLength = ConfigurationManager.AppSettings["keyLength"].ToString();
                //string keyLocation = ConfigurationManager.AppSettings["keyLocation"].ToString();
                //password = RSAEncrypt.DecryptData(password, keyLength, keyLocation);
                WindowsImpersonationContext wic = doImpersonation(svcUserName, domain, password);
                return wic;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorRoutine(new Exception("getWic() Error: " + ex.ToString()), ErrorMessage.NOTIFY_APP_ERROR);
                return null;
            }
        }
        #region Errors
        const int NO_ERROR = 0;
        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_ALREADY_ASSIGNED = 85;
        const int ERROR_BAD_DEVICE = 1200;
        const int ERROR_BAD_NET_NAME = 67;
        const int ERROR_BAD_PROVIDER = 1204;
        const int ERROR_CANCELLED = 1223;
        const int ERROR_EXTENDED_ERROR = 1208;
        const int ERROR_INVALID_ADDRESS = 487;
        const int ERROR_INVALID_PARAMETER = 87;
        const int ERROR_INVALID_PASSWORD = 1216;
        const int ERROR_MORE_DATA = 234;
        const int ERROR_NO_MORE_ITEMS = 259;
        const int ERROR_NO_NET_OR_BAD_PATH = 1203;
        const int ERROR_NO_NETWORK = 1222;
        const int ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;
        const int ERROR_BAD_PROFILE = 1206;
        const int ERROR_CANNOT_OPEN_PROFILE = 1205;
        const int ERROR_DEVICE_IN_USE = 2404;
        const int ERROR_NOT_CONNECTED = 2250;
        const int ERROR_OPEN_FILES = 2401;
        private struct ErrorClass
        {
            public int num;
            public string message;
            public ErrorClass(int num, string message)
            {
                this.num = num;
                this.message = message;
             }
        }
        private static ErrorClass[] ERROR_LIST = new ErrorClass[] {
            new ErrorClass(ERROR_ACCESS_DENIED, "Error: Access Denied"),
            new ErrorClass(ERROR_ALREADY_ASSIGNED, "Error: Already Assigned"),
            new ErrorClass(ERROR_BAD_DEVICE, "Error: Bad Device"),
            new ErrorClass(ERROR_BAD_NET_NAME, "Error: Bad Net Name"),
            new ErrorClass(ERROR_BAD_PROVIDER, "Error: Bad Provider"),
            new ErrorClass(ERROR_CANCELLED, "Error: Cancelled"),
            new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"),
            new ErrorClass(ERROR_INVALID_ADDRESS, "Error: Invalid Address"),
            new ErrorClass(ERROR_INVALID_PARAMETER, "Error: Invalid Parameter"),
            new ErrorClass(ERROR_INVALID_PASSWORD, "Error: Invalid Password"),
            new ErrorClass(ERROR_MORE_DATA, "Error: More Data"),
            new ErrorClass(ERROR_NO_MORE_ITEMS, "Error: No More Items"),
            new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Error: No Net Or Bad Path"),
            new ErrorClass(ERROR_NO_NETWORK, "Error: No Network"),
            new ErrorClass(ERROR_SESSION_CREDENTIAL_CONFLICT, "Error: Credential Conflict"),
            new ErrorClass(ERROR_BAD_PROFILE, "Error: Bad Profile"),
            new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Error: Cannot Open Profile"),
            new ErrorClass(ERROR_DEVICE_IN_USE, "Error: Device In Use"),
            new ErrorClass(ERROR_NOT_CONNECTED, "Error: Not Connected"),
            new ErrorClass(ERROR_OPEN_FILES, "Error: Open Files"),
        };
        private static string GetError(int errNum)
        {
            foreach (ErrorClass er in ERROR_LIST)
            {
                if (er.num == errNum) return er.message;
            }
            return "Error: Unknown, " + errNum;
        }
        #endregion
    }
