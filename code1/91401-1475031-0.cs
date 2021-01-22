    using System.Net.NetworkInformation;
    using System.Net;
     private static bool IsPortAvailable(int port)
     {
            IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] activeListeners = globalProperties.GetActiveTcpListeners();
            if (activeListeners.Any(conn => conn.Port == port))
            {
                return true;
            }
            return false;
     }
