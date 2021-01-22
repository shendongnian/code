    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Security.Permissions;
    
    [assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode = true)]
    [assembly: PermissionSetAttribute(SecurityAction.RequestMinimum, Name = "FullTrust")]
    public class ImpersonationDemo
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
            String lpszUsername, 
            String lpszDomain, 
            String lpszPassword, 
            int dwLogonType, 
            int dwLogonProvider,
            ref IntPtr phToken);
    
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
    
        // Test harness.
        // If you incorporate this code into a DLL, be sure to demand FullTrust.
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public static void Main(string[] args)
        {
            IntPtr tokenHandle = new IntPtr(0);
            try
            {
                string userName, domainName;
                // Get the user token for the specified user, domain, and password using the 
                // unmanaged LogonUser method.  
                // The local machine name can be used for the domain name to impersonate a user on this machine.
                Console.Write("Enter the name of the domain on which to log on: ");
                domainName = Console.ReadLine();
    
                Console.Write("Enter the login of a user on {0} that you wish to impersonate: ", domainName);
                userName = Console.ReadLine();
    
                Console.Write("Enter the password for {0}: ", userName);
    
                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_INTERACTIVE = 2;
    
                tokenHandle = IntPtr.Zero;
    
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = LogonUser(
                    userName, 
                    domainName, 
                    Console.ReadLine(),
                    3,
                    LOGON32_PROVIDER_DEFAULT,
                    ref tokenHandle);
    
                Console.WriteLine("LogonUser called.");
    
                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    Console.WriteLine("LogonUser failed with error code : {0}", ret);
                    throw new System.ComponentModel.Win32Exception(ret);
                }
    
                Console.WriteLine("Did LogonUser Succeed? " + (returnValue ? "Yes" : "No"));
                Console.WriteLine("Value of Windows NT token: " + tokenHandle);
    
                // Check the identity.
                Console.WriteLine("Before impersonation: " + WindowsIdentity.GetCurrent().Name);
                // Use the token handle returned by LogonUser.
                
                WindowsIdentity newId = new WindowsIdentity(tokenHandle);
                
                using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                {
                    // Check the identity. Here you shoul place code that will be executed on belaf of other login.
                    Console.WriteLine("After impersonation: " + WindowsIdentity.GetCurrent().Name);
                    GC.KeepAlive(impersonatedUser);
                }
    
                // Check the identity.
                Console.WriteLine("After Undo: " + WindowsIdentity.GetCurrent().Name);
    
                // Free the tokens.
                if (tokenHandle != IntPtr.Zero)
                    CloseHandle(tokenHandle);
    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred. " + ex.Message);
            }
    
        }
    }
