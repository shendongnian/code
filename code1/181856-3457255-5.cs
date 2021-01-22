    using System.Linq;
    using System.Net.NetworkInformation;
    
    var nic = NetworkInterface
         .GetAllNetworkInterfaces()
         .FirstOrDefault(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback && i.NetworkInterfaceType != NetworkInterfaceType.Tunnel);
    var name = nic.Name;
