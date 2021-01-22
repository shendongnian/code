    using System.Net;
    private bool IsDriveReady(string serverName)
    {
       // ***  SET YOUR TIMEOUT HERE  ***     
       int timeout = 5;    // 5 seconds 
       System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
       System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
       options.DontFragment = true;      
       // Enter a valid ip address     
       string ipAddressOrHostName = serverName;
       string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
       byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
       System.Net.NetworkInformation.PingReply reply = pingSender.Send(ipAddressOrHostName, timeout, buffer, options);
       return (reply.Status == System.Net.NetworkInformation.IPStatus.Success);
    }
