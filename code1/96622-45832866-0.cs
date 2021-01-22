     public static string GetMacAddressPhysicalNetworkInterface()
        {
            
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
            ("Select MACAddress,PNPDeviceID FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND" +
             " PNPDeviceID IS NOT NULL AND" +
             " PhysicalAdapter = true");
            ManagementObjectCollection mObject = searcher.Get();
            string macs = (from ManagementObject obj in mObject
                    let pnp = obj["PNPDeviceID"].ToString()
                    where !(pnp.Contains("ROOT\\"))
                    //where  pnp.Contains("PCI\\")  || pnp.Contains("USB\\")
                    select obj).Select(obj => obj["MACAddress"].ToString())
                .Aggregate<string, string>(null, (mac, currentMac) => mac + currentMac.Replace(":", string.Empty) + ",");
            return !string.IsNullOrEmpty(macs) ? macs.Substring(0, macs.Length - 1) : macs;
        }
        public static NetworkInterface GetPhysicalNetworkInterface(string macAddressPhysicalNetworkInterface)
        {
            return NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(currentNetworkInterface => string.Equals(currentNetworkInterface.GetPhysicalAddress().ToString(), macAddressPhysicalNetworkInterface, StringComparison.CurrentCultureIgnoreCase));
        }
