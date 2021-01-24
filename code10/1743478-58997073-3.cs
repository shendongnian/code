        public class BroadcastAddress
        {
            public IPAddress IPAddress { get; set; }
            public IPAddress BroadcastIPAddress { get; set; }
            public NetworkInterfaceType NetworkInterfaceType { get; set; }
        }
        public static IEnumerable<BroadcastAddress> GetBroadcastAddresses()
        {
            List<BroadcastAddress> broadcastAddresses = new List<BroadcastAddress>();
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface != null 
                    && (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                    ||  networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    IPInterfaceProperties iPInterfaceProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection unicastIPAddressInformationCollection = iPInterfaceProperties.UnicastAddresses;
                    foreach (UnicastIPAddressInformation unicastIPAddressInformation in unicastIPAddressInformationCollection)
                    {
                        if (unicastIPAddressInformation.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            IPAddress broadcastIPAddress = 
                                new IPAddress(unicastIPAddressInformation.Address.Address | (UInt32.MaxValue ^ (UInt32)(unicastIPAddressInformation.IPv4Mask.Address)));
                            broadcastAddresses.Add(new BroadcastAddress()
                            {
                                IPAddress = unicastIPAddressInformation.Address,
                                BroadcastIPAddress = broadcastIPAddress,
                                NetworkInterfaceType = networkInterface.NetworkInterfaceType
                            });
                        }
                    }
                }
            }
            return broadcastAddresses;
        }
