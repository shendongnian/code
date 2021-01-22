    	/// <summary>
		/// Sets the ip address.
		/// </summary>
		/// <param name="nicName">Name of the nic.</param>
		/// <param name="ipAddress">The ip address.</param>
		/// <param name="subnetMask">The subnet mask.</param>
		/// <param name="gateway">The gateway.</param>
		/// <param name="dns1">The DNS1.</param>
		/// <param name="dns2">The DNS2.</param>
		/// <returns></returns>
		public static bool SetIpAddress(
			string nicName,
			string ipAddress,
			string subnetMask,
			string gateway = null,
			string dns1 = null,
			string dns2 = null)
		{
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc = mc.GetInstances();
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			NetworkInterface networkInterface = interfaces.FirstOrDefault(x => x.Name == nicName);
			string nicDesc = nicName;
			if (networkInterface != null)
			{
				nicDesc = networkInterface.Description;
			}
			foreach (ManagementObject mo in moc)
			{
				if ((bool)mo["IPEnabled"] == true
					&& mo["Description"].Equals(nicDesc) == true)
				{
					try
					{
						ManagementBaseObject newIP = mo.GetMethodParameters("EnableStatic");
						newIP["IPAddress"] = new string[] { ipAddress };
						newIP["SubnetMask"] = new string[] { subnetMask };
						ManagementBaseObject setIP = mo.InvokeMethod("EnableStatic", newIP, null);
						if (gateway != null)
						{
							ManagementBaseObject newGateway = mo.GetMethodParameters("SetGateways");
							newGateway["DefaultIPGateway"] = new string[] { gateway };
							newGateway["GatewayCostMetric"] = new int[] { 1 };
							ManagementBaseObject setGateway = mo.InvokeMethod("SetGateways", newGateway, null);
						}
						if (dns1 != null || dns2 != null)
						{
							ManagementBaseObject newDns = mo.GetMethodParameters("SetDNSServerSearchOrder");
							var dns = new List<string>();
							if (dns1 != null)
							{
								dns.Add(dns1);
							}
							if (dns2 != null)
							{
								dns.Add(dns2);
							}
							newDns["DNSServerSearchOrder"] = dns.ToArray();
							ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDns, null);
						}
					}
					catch
					{
						return false;
					}
				}
			}
			return true;
		}
        /// <summary>
		/// Sets the DHCP.
		/// </summary>
		/// <param name="nicName">Name of the nic.</param>
		public static bool SetDHCP(string nicName)
		{
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc = mc.GetInstances();
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			NetworkInterface networkInterface = interfaces.FirstOrDefault(x => x.Name == nicName);
			string nicDesc = nicName;
			if (networkInterface != null)
			{
				nicDesc = networkInterface.Description;
			}
			foreach (ManagementObject mo in moc)
			{
				if ((bool)mo["IPEnabled"] == true
					&& mo["Description"].Equals(nicDesc) == true)
				{
					try
					{
						ManagementBaseObject newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
						newDNS["DNSServerSearchOrder"] = null;
						ManagementBaseObject enableDHCP = mo.InvokeMethod("EnableDHCP", null, null);
						ManagementBaseObject setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
					}
					catch
					{
						return false;
					}
				}
			}
			return true;
		}
