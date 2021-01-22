    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    public static class Win32Authentication
    {
        private class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle() // called by P/Invoke
                : base(true)
            {
            }
            protected override bool ReleaseHandle()
            {
                return CloseHandle(this.handle);
            }
        }
        private enum LogonType : uint
        {
            Network = 3, // LOGON32_LOGON_NETWORK
        }
        private enum LogonProvider : uint
        {
            WinNT50 = 3, // LOGON32_PROVIDER_WINNT50
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(
            string userName, string domain, string password,
            LogonType logonType, LogonProvider logonProvider,
            out SafeTokenHandle token);
        public static void AuthenticateUser(string userName, string password)
        {
            string domain = null;
            string[] parts = userName.Split('\\');
            if (parts.Length == 2)
            {
                domain = parts[0];
                userName = parts[1];
            }
            SafeTokenHandle token;
            if (LogonUser(userName, domain, password, LogonType.Network, LogonProvider.WinNT50, out token))
                token.Dispose();
            else
                throw new Win32Exception(); // calls Marshal.GetLastWin32Error()
        }
    }
