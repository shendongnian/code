    using System;
    using System.Security.Principal;
    
    namespace ManageExclusion
    {
        public static class UserIdentity
    
        {
            // concept borrowed from 
            // https://msdn.microsoft.com/en-us/library/system.security.principal.windowsidentity(v=vs.110).aspx
    
            public static string GetUser()
            {
                IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
                WindowsIdentity windowsIdentity = new WindowsIdentity(accountToken);
                return windowsIdentity.Name;
            }
        }
    }
