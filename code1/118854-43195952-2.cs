    public static bool IsAvailableNetworkActive()
    {
        // only recognizes changes related to Internet adapters
        if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) return false;
        // however, this will include all adapters -- filter by opstatus and activity
        NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
        return (from face in interfaces
                where face.OperationalStatus == OperationalStatus.Up
                where (face.NetworkInterfaceType != NetworkInterfaceType.Tunnel) && (face.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                where (!(face.Name.ToLower().Contains("virtual") || face.Description.ToLower().Contains("virtual")))
                select face.GetIPv4Statistics()).Any(statistics => (statistics.BytesReceived > 0) && (statistics.BytesSent > 0));
    }
