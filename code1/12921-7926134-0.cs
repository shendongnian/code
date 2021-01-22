    /// <summary>
    /// Helper class to set networking configuration like IP address, DNS servers, etc.
    /// </summary>
    public class NetworkConfigurator
    {
        /// <summary>
        /// Set's a new IP Address and it's Submask of the local machine
        /// </summary>
        /// <param name="ipAddress">The IP Address</param>
        /// <param name="subnetMask">The Submask IP Address</param>
        /// <param name="gateway">The gateway.</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetIP(string ipAddress, string subnetMask, string gateway)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(managementObject => (bool)managementObject["IPEnabled"]))
                    {
                        using (var newIP = managementObject.GetMethodParameters("EnableStatic"))
                        {
                            // Set new IP address and subnet if needed
                            if ((!String.IsNullOrEmpty(ipAddress)) || (!String.IsNullOrEmpty(subnetMask)))
                            {
                                if (!String.IsNullOrEmpty(ipAddress))
                                {
                                    newIP["IPAddress"] = new[] { ipAddress };
                                }
                                if (!String.IsNullOrEmpty(subnetMask))
                                {
                                    newIP["SubnetMask"] = new[] { subnetMask };
                                }
                                managementObject.InvokeMethod("EnableStatic", newIP, null);
                            }
                            // Set mew gateway if needed
                            if (!String.IsNullOrEmpty(gateway))
                            {
                                using (var newGateway = managementObject.GetMethodParameters("SetGateways"))
                                {
                                    newGateway["DefaultIPGateway"] = new[] { newGateway };
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
        public void SetNameservers(string nic, string dnsServers)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(objMO => (bool)objMO["IPEnabled"] && objMO["Caption"].Equals(nic)))
                    {
                        using (var newDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                        {
                            newDNS["DNSServerSearchOrder"] = dnsServers.Split(',');
                            managementObject.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                    }
                }
            }
        }
    }
