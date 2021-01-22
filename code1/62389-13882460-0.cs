    /* Libraries needed */
    using System.Linq;
    using System.Net.NetworkInformation;
    
    /*....
      ....
      ....*/
    private static bool IsPortBeingUsed(int port)
    {
        return IPGlobalProperties.GetIPGlobalProperties().
                    GetActiveTcpConnections().
                        Any(
                                tcpConnectionInformation => 
                                tcpConnectionInformation.LocalEndPoint.Port == port
                           );
    }
