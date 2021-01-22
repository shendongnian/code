    using System.Net;
    
    private bool CheckIfServer(IPAddress serverIP)
    {
        // Get all addresses assigned to this machine
        List<IPAddress> ipAddresses = new List<IPAddress>();
        ipAddresses.AddRange(Dns.GetHostAddresses(Dns.GetHostName()));
        // If desirable, also include the loopback adapter
        ipAddresses.Add(IPAddress.Loopback);
        // Detect if this machine contains the IP for the remote server
        // Note: This uses a Lambda Expression, which is only available .Net 3 or later
        return ipAddresses.Exists(i => i.ToString() == serverIP.ToString());
    }
