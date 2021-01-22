        /// <summary>
        /// returns the first MAC address from where is executed 
        /// </summary>
        /// <param name="flagUpOnly">if sets returns only the nic on Up status</param>
        /// <returns></returns>
        public static string[] getOperationalMacAddresses(Boolean flagUpOnly)
        {
            string[] macAddresses = new string[NetworkInterface.GetAllNetworkInterfaces().Count()];
            int i = 0;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up || !flagUpOnly)
                {
                    macAddresses[i] += ByteToHex(nic.GetPhysicalAddress().GetAddressBytes());
                    //break;
                    i++;
                }
            }
            return macAddresses;
        }
