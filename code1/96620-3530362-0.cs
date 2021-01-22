                ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select MACAddress,PNPDeviceID FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND PNPDeviceID IS NOT NULL");
                ManagementObjectCollection mObject = searcher.Get();
                foreach (ManagementObject obj in mObject)
                {
                    string pnp = obj["PNPDeviceID"].ToString();
                    if (pnp.Contains("PCI\\"))
                    {
                        string mac = obj["MACAddress"].ToString();
                        mac=mac.Replace(":", string.Empty);
                        return mac;
                    }
                }
