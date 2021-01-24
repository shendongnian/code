    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web;
    using System.Web.UI.WebControls;
    
    namespace BBVA.Canales.Front.Net.UI.WebApp.Servicios.ViewModels
    {
        public class NetworkShare
        {
            [DllImport("Mpr.dll")]
            private static extern int WNetUseConnection(
                IntPtr hwndOwner,
                NETRESOURCE lpNetResource,
                string lpPassword,
                string lpUserID,
                int dwFlags,
                string lpAccessName,
                string lpBufferSize,
                string lpResult
                );
    
            [DllImport("Mpr.dll")]
            private static extern int WNetCancelConnection(
                string lpName,
                bool fForce
                );
    
            [StructLayout(LayoutKind.Sequential)]
            private class NETRESOURCE
            {
                public int dwScope = 0;
                public int dwType = 0;
                public int dwDisplayType = 0;
                public int dwUsage = 0;
                public string lpLocalName = "";
                public string lpRemoteName = "";
                public string lpComment = "";
                public string lpProvider = "";
            }
    
            const int RESOURCETYPE_DISK = 0x00000001;
            const int CONNECT_UPDATE_PROFILE = 0x00000001;
    
    
            public static void ConnectToShare(string uri, string username, string password, string idFile, HttpPostedFileBase file)
            {
                //Create netresource and point it at the share
                NETRESOURCE nr = new NETRESOURCE();
                nr.dwType = RESOURCETYPE_DISK;
                nr.lpRemoteName = uri;
    
                //Create the share
                int ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);
    
                file.SaveAs(@"\\c:\Desktop\FolderName\" + idFile);
    
            }
    
            public static void DisconnectFromShare(string uri, bool force)
            {
                //remove the share
                int ret = WNetCancelConnection(uri, force);
    
            }
    
    
    
        }
    }
