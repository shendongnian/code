    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    namespace SeekCopySupportTool.Business
    {
    public class NetWorkDrive : IDisposable
    {
        #region private fields
        private string m_DriveLetter = string.Empty;
        private string m_FullDriveLetter = string.Empty;
        private bool m_Disposed = false;
        //this list specifies the drive-letters, whitch will be used to map networkfolders
        private string[] possibleDriveLetters = new string[] 
        { 
            "G:\\", 
            "H:\\", 
            "I:\\", 
            "J:\\", 
            "K:\\", 
            "L:\\", 
            "M:\\", 
            "N:\\", 
            "O:\\", 
            "P:\\", 
            "Q:\\", 
            "R:\\", 
            "S:\\", 
            "T:\\", 
            "U:\\", 
            "V:\\", 
            "W:\\", 
            "X:\\", 
            "Y:\\", 
            "Z:\\" 
        };
        #endregion
        #region public properties
        public string DriveLetter
        {
            get { return m_DriveLetter; }
            set { m_DriveLetter = value; }
        }
        public string FullDriveLetter
        {
            get { return m_FullDriveLetter; }
            set { m_FullDriveLetter = value; }
        }
        #endregion
        #region .ctor
        public NetWorkDrive(string folderPath)
        {
            m_FullDriveLetter = MapFolderAsNetworkDrive(folderPath);
            if (string.IsNullOrEmpty(m_FullDriveLetter))
            {
                throw new Exception("no free valid drive-letter found");
            }
            m_DriveLetter = m_FullDriveLetter.Substring(0,2);
        }
        #endregion
        #region private methods
        /// maps a given folder to a free drive-letter (f:\)
        /// <param name="folderPath">the folder to map</param>
        /// <returns>the drive letter in this format: "(letter):\" -> "f:\"</returns>
        /// <exception cref="Win32Exception">if the connect returns an error</exception>
        private string MapFolderAsNetworkDrive(string folderPath)
        {
            string result = GetFreeDriveLetter();
            NETRESOURCE myNetResource = new NETRESOURCE();
            myNetResource.dwScope = ResourceScope.RESOURCE_GLOBALNET;
            myNetResource.dwType = ResourceType.RESOURCETYPE_ANY;
            myNetResource.dwDisplayType = ResourceDisplayType.RESOURCEDISPLAYTYPE_SERVER;
            myNetResource.dwUsage = ResourceUsage.RESOURCEUSAGE_CONNECTABLE;
            myNetResource.lpLocalName = result.Substring(0,2);
            myNetResource.lpRemoteName = folderPath;
            myNetResource.lpProvider = null;
            int errorcode = WNetAddConnection2(myNetResource, null, null, 0);
            if(errorcode != 0)
            {
                throw new Win32Exception(errorcode);
            }
            return result;
        }
        private void DisconnectNetworkDrive()
        {
            int CONNECT_UPDATE_PROFILE = 0x1;
            int errorcode = WNetCancelConnection2(m_DriveLetter, CONNECT_UPDATE_PROFILE, true);
            if (errorcode != 0)
            {
                throw new Win32Exception(errorcode);
            }
        }
        private string GetFreeDriveLetter()
        {
            //first get the existing driveletters
            const int size = 512;
            char[] buffer = new char[size];
            uint code = GetLogicalDriveStrings(size, buffer);
            if (code == 0)
            {                
                return "";
            }
            List<string> list = new List<string>();
            int start = 0;
            for (int i = 0; i < code; ++i)
            {
                if (buffer[i] == 0)
                {
                    string s = new string(buffer, start, i - start);
                    list.Add(s);
                    start = i + 1;
                }
            }            
            foreach (string s in possibleDriveLetters)
            {                
                if (!list.Contains(s))
                {
                    return s;
                }
            }
            return null;
        }        
        #endregion
        #region dll imports
        /// <summary>
        /// to connect to a networksource
        /// </summary>
        /// <param name="netResource"></param>
        /// <param name="password">null the function uses the current default password associated with the user specified by the username parameter ("" the function does not use a password)</param>
        /// <param name="username">null the function uses the default user name (The user context for the process provides the default user name)</param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("mpr.dll")]
        //public static extern int WNetAddConnection2(ref NETRESOURCE netResource, string password, string username, int flags);
        private static extern int WNetAddConnection2([In] NETRESOURCE netResource, string password, string username, int flags);
        /// <summary>
        /// to disconnect the networksource
        /// </summary>
        /// <param name="lpName"></param>
        /// <param name="dwFlags"></param>
        /// <param name="bForce"></param>
        /// <returns></returns>
        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool bForce);
        /// <param name="nBufferLength"></param>
        /// <param name="lpBuffer"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern uint GetLogicalDriveStrings(uint nBufferLength, [Out] char[] lpBuffer);
        #endregion
        #region enums/structs
        /// <example>
        /// NETRESOURCE myNetResource = new NETRESOURCE();
        /// myNetResource.dwScope = 2;
        /// myNetResource.dwType = 1;
        /// myNetResource.dwDisplayType = 3;
        /// myNetResource.dwUsage = 1;
        /// myNetResource.LocalName = "z:";
        /// myNetResource.RemoteName = @"\servername\sharename";
        /// myNetResource.Provider = null;
        /// </example>
        [StructLayout(LayoutKind.Sequential)]
        public class NETRESOURCE
        {
            public ResourceScope dwScope = 0;
            public ResourceType dwType = 0;
            public ResourceDisplayType dwDisplayType = 0;
            public ResourceUsage dwUsage = 0;
            public string lpLocalName = null;
            public string lpRemoteName = null;
            public string lpComment = null;
            public string lpProvider = null;
        };
        public enum ResourceScope : int
        {
            RESOURCE_CONNECTED = 1,
            RESOURCE_GLOBALNET,
            RESOURCE_REMEMBERED,
            RESOURCE_RECENT,
            RESOURCE_CONTEXT
        };
        public enum ResourceType : int
        {
            RESOURCETYPE_ANY,
            RESOURCETYPE_DISK,
            RESOURCETYPE_PRINT,
            RESOURCETYPE_RESERVED
        };
        public enum ResourceUsage
        {
            RESOURCEUSAGE_CONNECTABLE = 0x00000001,
            RESOURCEUSAGE_CONTAINER = 0x00000002,
            RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
            RESOURCEUSAGE_SIBLING = 0x00000008,
            RESOURCEUSAGE_ATTACHED = 0x00000010,
            RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
        };
        public enum ResourceDisplayType
        {
            RESOURCEDISPLAYTYPE_GENERIC,
            RESOURCEDISPLAYTYPE_DOMAIN,
            RESOURCEDISPLAYTYPE_SERVER,
            RESOURCEDISPLAYTYPE_SHARE,
            RESOURCEDISPLAYTYPE_FILE,
            RESOURCEDISPLAYTYPE_GROUP,
            RESOURCEDISPLAYTYPE_NETWORK,
            RESOURCEDISPLAYTYPE_ROOT,
            RESOURCEDISPLAYTYPE_SHAREADMIN,
            RESOURCEDISPLAYTYPE_DIRECTORY,
            RESOURCEDISPLAYTYPE_TREE,
            RESOURCEDISPLAYTYPE_NDSCONTAINER
        };
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
        #region overrides/virtuals
        public override string ToString()
        {
            return m_FullDriveLetter;
        }
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    DisconnectNetworkDrive();
                }
                m_Disposed = true;
            }
        }
        #endregion
    }
    }
