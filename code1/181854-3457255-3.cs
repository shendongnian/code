    using System.Linq;
    using System.Net.NetworkInformation;
    
    var nic = NetworkInterface
         .GetAllNetworkInterfaces()
         .Where(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback && i.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
         .FirstOrDefault();
    var name = nic.Name;
