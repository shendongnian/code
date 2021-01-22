    string retVal = "";
            var nic = NetworkInterface
                      .GetAllNetworkInterfaces()
                      .Where(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback && i.NetworkInterfaceType != NetworkInterfaceType.Tunnel && i.Description == "Cisco Systems VPN Adapter");
            var name = nic.FirstOrDefault();
            if (name != null)
            {
                retVal = name.Name.ToString();
              
            }
            else
            {
                retVal = "NotFound";
            }
            return retVal;
