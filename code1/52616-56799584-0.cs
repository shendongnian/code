%ProjectPath%/SecureStringsEasy.cs
    using System;
    using System.Security;
    using System.Runtime.InteropServices;
    namespace SecureStringsEasy
    {
        public static class MyExtensions
        {
            public static SecureString ToSecureString(string input)
            {
                SecureString secureString = new SecureString();
                foreach (var item in input)
                {
                    secureString.AppendChar(item);
                }
                return secureString;
            }
            public static string ToNormalString(SecureString input)
            {
                IntPtr strptr = Marshal.SecureStringToBSTR(input);
                string normal = Marshal.PtrToStringBSTR(strptr);
                Marshal.ZeroFreeBSTR(strptr);
                return normal;
            }
        }
    }
