    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    ...
    string[] ipAddresses = NetworkInterface.GetAllNetworkInterfaces()
    	.SelectMany(c=>c.GetIPProperties().UnicastAddresses
    		.Where(d=>d.Address.AddressFamily == AddressFamily.InterNetwork)
    		.Select(d=>d.Address.ToString())
    	).ToArray();
