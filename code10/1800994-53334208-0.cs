        /// <summary>
        /// uses WMI to get all available cameras and add them to the list
        /// </summary>
        private void GetAvailableCameraList()
        {
            AvailableCameras = new List<string>();
            string wmiQuery = string.Format("SELECT * FROM Win32_PnPSignedDriver");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
            ManagementObjectCollection retObjectCollection = searcher.Get();
            foreach (var WmiObject in retObjectCollection)
            {
                    if (WmiObject["DeviceClass"] != null && WmiObject["DeviceClass"].ToString().Equals("IMAGE"))
                    {
                        AvailableCameras.Add(WmiObject["DeviceName"].ToString());
                    }
            }
        }
