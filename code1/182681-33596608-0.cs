    try {				  
			ManagementObjectSearcher searcher =
				new ManagementObjectSearcher("root\\WMI",
				"SELECT * FROM WmiMonitorBasicDisplayParams");	  
			foreach (ManagementObject queryObj in searcher.Get()) {
				Debug.WriteLine("-----------------------------------");
				Debug.WriteLine("WmiMonitorBasicDisplayParams instance");
				Debug.WriteLine("-----------------------------------");
				Debug.WriteLine("Description: {0}", queryObj["SupportedDisplayFeatures"]);
			}
		} catch (ManagementException e) {
			MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
		}
