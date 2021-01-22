            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface iface in interfaces)
            {
                IPInterfaceProperties properties = iface.GetIPProperties();
                foreach (UnicastIPAddressInformation address in properties.UnicastAddresses)
                {
                    Console.WriteLine(
                        "{0} (Mask: {1})",
                        address.Address,
                        address.IPv4Mask
                        );
                }
            }
