    using System;
    using System.Management;
    
    namespace WindowsFormsApplication_CS
    {
        class NetworkManagement
        {
            /// <summary>
            /// Set's a new IP Address and it's Submask of the local machine
            /// </summary>
            /// <param name="ip_address">The IP Address</param>
            /// <param name="subnet_mask">The Submask IP Address</param>
            /// <remarks>Requires a reference to the System.Management namespace</remarks>
            public void setIP(string ip_address, string subnet_mask)
            {
                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
    
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        try
                        {
                            ManagementBaseObject setIP;
                            ManagementBaseObject newIP =
                                objMO.GetMethodParameters("EnableStatic");
    
                            newIP["IPAddress"] = new string[] { ip_address };
                            newIP["SubnetMask"] = new string[] { subnet_mask };
    
                            setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
    
    
                    }
                }
            }
            /// <summary>
            /// Set's a new Gateway address of the local machine
            /// </summary>
            /// <param name="gateway">The Gateway IP Address</param>
            /// <remarks>Requires a reference to the System.Management namespace</remarks>
            public void setGateway(string gateway)
            {
                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
    
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        try
                        {
                            ManagementBaseObject setGateway;
                            ManagementBaseObject newGateway =
                                objMO.GetMethodParameters("SetGateways");
    
                            newGateway["DefaultIPGateway"] = new string[] { gateway };
                            newGateway["GatewayCostMetric"] = new int[] { 1 };
    
                            setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            /// <summary>
            /// Set's the DNS Server of the local machine
            /// </summary>
            /// <param name="NIC">NIC address</param>
            /// <param name="DNS">DNS server address</param>
            /// <remarks>Requires a reference to the System.Management namespace</remarks>
            public void setDNS(string NIC, string DNS)
            {
                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
    
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Caption"].Equals(NIC))
                        {
                            try
                            {
                                ManagementBaseObject newDNS =
                                    objMO.GetMethodParameters("SetDNSServerSearchOrder");
                                newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                                ManagementBaseObject setDNS =
                                    objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            /// <summary>
            /// Set's WINS of the local machine
            /// </summary>
            /// <param name="NIC">NIC Address</param>
            /// <param name="priWINS">Primary WINS server address</param>
            /// <param name="secWINS">Secondary WINS server address</param>
            /// <remarks>Requires a reference to the System.Management namespace</remarks>
            public void setWINS(string NIC, string priWINS, string secWINS)
            {
                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
    
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Caption"].Equals(NIC))
                        {
                            try
                            {
                                ManagementBaseObject setWINS;
                                ManagementBaseObject wins =
                                objMO.GetMethodParameters("SetWINSServer");
                                wins.SetPropertyValue("WINSPrimaryServer", priWINS);
                                wins.SetPropertyValue("WINSSecondaryServer", secWINS);
    
                                setWINS = objMO.InvokeMethod("SetWINSServer", wins, null);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                }
            } 
        }
    }
