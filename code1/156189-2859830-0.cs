    using System;
    using System.Net.NetworkInformation;
    using System.Net;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                Ping pingObj = new Ping();
    
                for (int i = 0; i < adapters.Length; i++)
                {
                    Console.WriteLine("Network adapter: {0}", adapters[i].Name);
                    Console.WriteLine("    Status:            {0}", adapters[i].OperationalStatus.ToString());
                    Console.WriteLine("    Interface:         {0}", adapters[i].NetworkInterfaceType.ToString());
                    Console.WriteLine("    Description:       {0}", adapters[i].Description);
                    Console.WriteLine("    ID:                {0}", adapters[i].Id);
                    Console.WriteLine("    Speed:             {0}", adapters[i].Speed);
                    Console.WriteLine("    SupportsMulticast: {0}", adapters[i].SupportsMulticast);
                    Console.WriteLine("    IsReceiveOnly:     {0}", adapters[i].IsReceiveOnly);
                    Console.WriteLine("    MAC:               {0}", adapters[i].GetPhysicalAddress().ToString());
                    if (adapters[i].NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        IPInterfaceProperties IPIP = adapters[i].GetIPProperties();
                        if (IPIP != null)
                        {
                            // First ensure that a gateway is reachable:
                            bool bGateWayReachable = false;
                            foreach (GatewayIPAddressInformation gw in IPIP.GatewayAddresses)
                            {
                                Console.WriteLine("    Gateway:     {0} - ", gw.Address.ToString());
    
                                // TODO: Do this many times to establish an average:
                                PingReply pr = pingObj.Send(gw.Address, 2000);
    
                                if (pr.Status == IPStatus.Success)
                                {
                                    Console.WriteLine("    reachable ({0}ms)", pr.RoundtripTime);
                                    bGateWayReachable = true;
                                    break;
                                }
                                else
                                    Console.WriteLine("    NOT reachable");
                            }
                            // Next, see if any DNS server is available. These are most likely to be off-site and more highly available.
                            if (bGateWayReachable == true)
                            {
                                foreach (IPAddress ipDNS in IPIP.DnsAddresses)
                                {
                                    Console.WriteLine("    DNS:         {0} - ", ipDNS.ToString());
                                    PingReply pr = pingObj.Send(ipDNS, 5000); // was 2000, increased for Cor in UK office
                                    if (pr.Status == IPStatus.Success)
                                    {
                                        Console.WriteLine("    reachable ({0}ms)", pr.RoundtripTime);
                                        Console.WriteLine("    --- SUCCESS ---");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("    NOT reachable");
                                }
                            }
                        } // if (IPIP != null)
                    }
                } // foreach (NetworkInterface n in adapters)
    
                Console.ReadLine();
            }
        }
    }
