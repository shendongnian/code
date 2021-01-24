    /// <summary>
    /// Accessing network share folder.
    /// </summary>
    public class NetUse
    {
        string _sharename, _user, _password;
        public NetUse(string ShareFolder,string Username, string  Password)
        {
            _sharename = ShareFolder;
            _user = Username;
            _password = Password;
        }
        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2A(ref NetResource pstNetRes, string psPassword, string psUsername, int piFlags);
        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);
        [StructLayout(LayoutKind.Sequential)]
        private struct NetResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }
        private const int RESOURCETYPE_DISK = 0x1;
        public void Login()
        {
            string destinationDirectory =  _sharename;
            NetResource nr = new NetResource();
            nr.iScope = 2;
            nr.iType = RESOURCETYPE_DISK;
            nr.iDisplayType = 3;
            nr.iUsage = 1;
            nr.sRemoteName = destinationDirectory;
            nr.sLocalName = null;
            int flags = 0;
            int rc = WNetAddConnection2A(ref nr, _password, _user, flags);
            if (rc != 0) throw new Win32Exception(rc);
        }
        public void Logout()
        {
            string destinationDirectory = _sharename;
            int flags = 0;
            int rc = WNetCancelConnection2A(destinationDirectory, flags, Convert.ToInt32(false));
        }
    }
