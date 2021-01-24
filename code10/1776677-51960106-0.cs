    using System;
    public static class NativeMethods
    {
        public static Boolean ValidateAdminUser(String username, String password)
        {
            if (Environment.Is64BitProcess)
            {
                return NativeMethods64.ValidateAdminUser(String username, String password);
            }
            else
            {
                return NativeMethods32.ValidateAdminUser(String username, String password);
            }
        }
        private static class NativeMethods64
        {
            [DllImport("MyLibrary.amd64.dll", EntryPoint = "ValidateAdminUser", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern Boolean ValidateAdminUser(String username, String password);
        }
        private static class NativeMethods32
        {
            [DllImport("MyLibrary.x86.dll", EntryPoint = "ValidateAdminUser", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern Boolean ValidateAdminUser(String username, String password);
        }
    }
