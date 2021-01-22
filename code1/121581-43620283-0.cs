        private static string FindSerialPortForRFIDReaderCore()
        {
            string serialPort = "";
            List<string> ports = new List<string>();
            System.Management.ManagementObjectSearcher Searcher = new System.Management.ManagementObjectSearcher("Select * from WIN32_SerialPort");
            foreach (System.Management.ManagementObject Port in Searcher.Get())
            {
                if (Port["PNPDeviceID"].ToString().ToUpper().Contains("MacAddress")) 
                    ports.Add(Port["DeviceID"].ToString());
            }
            if (ports.Count > 1) // There are more than one Serial Ports created for the bluetooth device.
                serialPort = ports.OrderByDescending(p => p).FirstOrDefault();
            else if(ports.Count == 1)
                serialPort = ports[0];
            return serialPort;
        }
