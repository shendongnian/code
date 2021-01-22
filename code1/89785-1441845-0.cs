        public static void CopyFile(string from, string shareName, string username, string password)
        {
            NETRESOURCE nr = new NETRESOURCE();
            nr.dwType = ResourceType.RESOURCETYPE_DISK;
            nr.lpLocalName = null;
            nr.lpRemoteName = shareName;
            nr.lpProvider = null;
            int result = WNetAddConnection2(nr,  password,  username, 0);
            System.IO.File.Copy(from, System.IO.Path.Combine(shareName, System.IO.Path.GetFileName(from)));
        }
