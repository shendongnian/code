    public static class NetworkConfigurator
    {
        /// <summary>
        /// Set's a new IP Address and it's Submask of the local machine
        /// </summary>
        /// <param name="ipAddress">The IP Address</param>
        /// <param name="subnetMask">The Submask IP Address</param>
        /// <param name="gateway">The gateway.</param>
        /// <param name="nicDescription"></param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public static void SetIP(string nicDescription, string[] ipAddresses, string subnetMask, string gateway)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(mo => (bool)mo["IPEnabled"] && (string)mo["Description"] == nicDescription))
                    {
                        using (var newIP = managementObject.GetMethodParameters("EnableStatic"))
                        {
                            // Set new IP address and subnet if needed
                            if (ipAddresses != null || !String.IsNullOrEmpty(subnetMask))
                            {
                                if (ipAddresses != null)
                                {
                                    newIP["IPAddress"] = ipAddresses;
                                }
                                if (!String.IsNullOrEmpty(subnetMask))
                                {
                                    newIP["SubnetMask"] = Array.ConvertAll(ipAddresses, _ => subnetMask);
                                }
                                managementObject.InvokeMethod("EnableStatic", newIP, null);
                            }
                            // Set mew gateway if needed
                            if (!String.IsNullOrEmpty(gateway))
                            {
                                using (var newGateway = managementObject.GetMethodParameters("SetGateways"))
                                {
                                    newGateway["DefaultIPGateway"] = new[] { gateway };
                                    newGateway["GatewayCostMetric"] = new[] { 1 };
                                    managementObject.InvokeMethod("SetGateways", newGateway, null);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Set's the DNS Server of the local machine
        /// </summary>
        /// <param name="nic">NIC address</param>
        /// <param name="dnsServers">Comma seperated list of DNS server addresses</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public static void SetNameservers(string nicDescription, string[] dnsServers)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(mo => (bool)mo["IPEnabled"] && (string)mo["Description"] == nicDescription))
                    {
                        using (var newDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                        {
                            newDNS["DNSServerSearchOrder"] = dnsServers;
                            managementObject.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                    }
                }
            }
        }
    }
