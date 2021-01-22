    using Microsoft.Win32;
    
    namespace Extensions
    {
        public static class MyExtensions
        {
            public static string CompanyName(this RegistryKey key)
            {
                // this string goes in my resources file usually
                return (string)key.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion").GetValue("RegisteredOrganization");
            }
        }
    }
