    IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
    Console.WriteLine(ipProperties.HostName);
            foreach (NetworkInterface networkCard in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (GatewayIPAddressInformation gatewayAddr in networkCard.GetIPProperties().GatewayAddresses)
                {
                    Console.WriteLine("Network card: ");
                    Console.WriteLine("Interface type: {0}", networkCard.NetworkInterfaceType.ToString());
                    Console.WriteLine("Name: {0}", networkCard.Name);
                    Console.WriteLine("Id: {0}", networkCard.Id);
                    Console.WriteLine("Description: {0}", networkCard.Description);
                    Console.WriteLine("Gateway address: {0}", gatewayAddr.Address.ToString());
                    Console.WriteLine("IP: {0}", System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString());
                    Console.WriteLine("Speed: {0}", networkCard.Speed);
                    Console.WriteLine("MAC: {0}", networkCard.GetPhysicalAddress().ToString());
                }
            }
