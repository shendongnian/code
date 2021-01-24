                System.Net.NetworkInformation.UnicastIPAddressInformation mostSuitableIp = null;
                var networkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
                foreach (var network in networkInterfaces)
                {
                    if (network.OperationalStatus != System.Net.NetworkInformation.OperationalStatus.Up)
                    {
                        continue;
                    }
                    var properties = network.GetIPProperties();
                    if (properties.GatewayAddresses.Count == 0)
                    {
                        continue;
                    }
                    if (mostSuitableIp != null)
                    {
                        break;
                    }
                    foreach (var address in properties.UnicastAddresses)
                    {
                        if (address.Address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            continue;
                        }
                        if (System.Net.IPAddress.IsLoopback(address.Address))
                        {
                            continue;
                        }
                        if (mostSuitableIp == null && address.IsDnsEligible)
                        {
                            mostSuitableIp = address;
                            break;
                        }
                   }
                }
                thisIP = mostSuitableIp != null ? mostSuitableIp.Address.ToString() : "";
