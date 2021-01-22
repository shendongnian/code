    public class DriveWrapper
    {                    
        [StructLayout(LayoutKind.Sequential)]
        public struct NETRESOURCEA
        {
            public int dwScope;
            public int dwType;
            public int dwDisplayType;
            public int dwUsage;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpLocalName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpRemoteName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpProvider;
            public override String ToString()
            {
                String str = "LocalName: " + lpLocalName + " RemoteName: " + lpRemoteName
                      + " Comment: " + lpComment + " lpProvider: " + lpProvider;
                return (str);
            }
        }
        
        [DllImport("mpr.dll")]
        public static extern int WNetAddConnection2A(
              [MarshalAs(UnmanagedType.LPArray)] NETRESOURCEA[] lpNetResource,
              [MarshalAs(UnmanagedType.LPStr)] string lpPassword,
              [MarshalAs(UnmanagedType.LPStr)] string UserName,
              int dwFlags);       
        [DllImport("mpr.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int WNetCancelConnection2A(
              [MarshalAs(UnmanagedType.LPStr)]
            string lpName,
              int dwFlags,
              int fForce
              );
        
        public int GetDriveSpace(string shareName, string userName, string password)
        {
            NETRESOURCEA[] n = new NETRESOURCEA[1];
            n[0] = new NETRESOURCEA();
    
            n[0].dwScope = 0;
            n[0].dwType = 0;
            n[0].dwDisplayType = 0;
            n[0].dwUsage = 0;
    
            n[0].dwType = 1;
            
            n[0].lpLocalName = "x:";
            n[0].lpRemoteName = shareName;
            n[0].lpProvider = null;
            
            int res = WNetAddConnection2A(n, userName, password, 1);
    
            DriveInfo info = new DriveInfo("x:");
            int space = info.AvailableFreeSpace;
    
            int err = 0;
            err = WNetCancelConnection2A("x:", 0, 1);
    
            return space;
        }
    }
