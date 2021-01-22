        /// <summary>
        /// returns the mac address of the NIC with max speed.
        /// </summary>
        /// <returns></returns>
        private string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = "";
            long maxSpeed=-1;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                log.Debug("Found MAC Address: " + nic.GetPhysicalAddress().ToString() + " Type: " + nic.NetworkInterfaceType );
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed && !String.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH )
                {
                    log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac );
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }
            return macAddress;
        }
