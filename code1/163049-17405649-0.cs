    public static class CredentialSetter
    {
        public static void SetCredentials()
        {
            string Computername = "SomeComputer";
            //Create connection to remote computer'
            using (NetworkConnection nc = new NetworkConnection("\\\\" + Computername + "", new NetworkCredential("Domain\\Login", "Password")))
            {
                //try connecting using DirectoryEntry to the same machine and add me as a user'
                string strUserPath = string.Format("WinNT://{0}/{1},user", "DOMAIN", "USER");
                DirectoryEntry deGroup = new DirectoryEntry("WinNT://" + Computername + "/Administrators");
                deGroup.RefreshCache();
                //add and remove the user from the group'
                deGroup.Invoke("Add", strUserPath);
                deGroup.CommitChanges();
                Console.WriteLine("User Added to computer " + Computername);
                deGroup.Invoke("Remove", strUserPath);
                deGroup.CommitChanges();
                Console.WriteLine("User Removed from computer " + Computername);
                deGroup.Close();
            }
            Console.ReadLine();
        }
        public class NetworkConnection : IDisposable
        {
            private string _networkName;
            public NetworkConnection(string networkName, NetworkCredential credentials)
            {
                _networkName = networkName;
                dynamic netResource = new NetResource
                {
                    Scope = ResourceScope.GlobalNetwork,
                    ResourceType = ResourceType.Disk,
                    DisplayType = ResourceDisplaytype.Share,
                    RemoteName = networkName
                };
                dynamic result = WNetAddConnection2(netResource, credentials.Password, credentials.UserName, 0);
                if (result != 0)
                {
                    throw new IOException("Error connecting to remote share", result);
                }
            }
            ~NetworkConnection()
            {
                Dispose(false);
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected void Dispose(bool disposing)
            {
                WNetCancelConnection2(_networkName, 0, true);
            }
            [DllImport("mpr.dll")]
            private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);
            [DllImport("mpr.dll")]
            private static extern int WNetCancelConnection2(string name, int flags, bool force);
        }
        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }
        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        }
        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8
        }
        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x1,
            Server = 0x2,
            Share = 0x3,
            File = 0x4,
            Group = 0x5,
            Network = 0x6,
            Root = 0x7,
            Shareadmin = 0x8,
            Directory = 0x9,
            Tree = 0xa,
            Ndscontainer = 0xb
        }
    }
