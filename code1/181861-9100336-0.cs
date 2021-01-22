    public static void DisplayIPAddresses()
        {
            Console.WriteLine("\r\n****************************");
            Console.WriteLine("     IPAddresses");
            Console.WriteLine("****************************");
            StringBuilder sb = new StringBuilder();
            // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)     
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
              
            foreach (NetworkInterface network in networkInterfaces)
            {
                
                if (network.OperationalStatus == OperationalStatus.Up )
                {
                    if (network.NetworkInterfaceType == NetworkInterfaceType.Tunnel) continue;
                    if (network.NetworkInterfaceType == NetworkInterfaceType.Tunnel) continue;
                    //GatewayIPAddressInformationCollection GATE = network.GetIPProperties().GatewayAddresses;
                    // Read the IP configuration for each network   
                    IPInterfaceProperties properties = network.GetIPProperties();
                    //discard those who do not have a real gateaway 
                    if (properties.GatewayAddresses.Count > 0)
                    {
                        bool good = false;
                        foreach  (GatewayIPAddressInformation gInfo in properties.GatewayAddresses)
                        {
                            //not a true gateaway (VmWare Lan)
                            if (!gInfo.Address.ToString().Equals("0.0.0.0"))
                            {
                                sb.AppendLine(" GATEAWAY "+ gInfo.Address.ToString());
                                good = true;
                                break;
                            }
                        }
                        if (!good)
                        {
                            continue;
                        }
                    }
                    else {
                        continue;
                    }
                    // Each network interface may have multiple IP addresses       
                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        // We're only interested in IPv4 addresses for now       
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork) continue;
                        // Ignore loopback addresses (e.g., 127.0.0.1)    
                        if (IPAddress.IsLoopback(address.Address)) continue;
                         
                        if (!address.IsDnsEligible) continue;
                        if (address.IsTransient) continue; 
                         
                        sb.AppendLine(address.Address.ToString() + " (" + network.Name + ") nType:" + network.NetworkInterfaceType.ToString()     );
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }
   
