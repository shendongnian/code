    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    public class UncShareWithCredentials : IDisposable
    {
        private string _uncShare;
        public UncShareWithCredentials(string uncShare, string userName, string password)
        {
            var nr = new Native.NETRESOURCE
            {
                dwType = Native.RESOURCETYPE_DISK,
                lpRemoteName = uncShare
            };
            int result = Native.WNetUseConnection(IntPtr.Zero, nr, password, userName, 0, null, null, null);
            if (result != Native.NO_ERROR)
            {
                throw new Win32Exception(result);
            }
            _uncShare = uncShare;
        }
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_uncShare))
            {
                Native.WNetCancelConnection2(_uncShare, Native.CONNECT_UPDATE_PROFILE, false);
                _uncShare = null;
            }
        }
        private class Native
        {
            public const int RESOURCETYPE_DISK = 0x00000001;
            public const int CONNECT_UPDATE_PROFILE = 0x00000001;
            public const int NO_ERROR = 0;
            [DllImport("mpr.dll")]
            public static extern int WNetUseConnection(IntPtr hwndOwner, NETRESOURCE lpNetResource, string lpPassword, string lpUserID,
                int dwFlags, string lpAccessName, string lpBufferSize, string lpResult);
            [DllImport("mpr.dll")]
            public static extern int WNetCancelConnection2(string lpName, int dwFlags, bool fForce);
            [StructLayout(LayoutKind.Sequential)]
            public class NETRESOURCE
            {
                public int dwScope;
                public int dwType;
                public int dwDisplayType;
                public int dwUsage;
                public string lpLocalName;
                public string lpRemoteName;
                public string lpComment;
                public string lpProvider;
            }
        }
    }
