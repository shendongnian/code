		public static string GetIPAddress(string hostname)
		{
			IPHostEntry host;
			host = Dns.GetHostEntry(hostname);
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					//System.Diagnostics.Debug.WriteLine("LocalIPadress: " + ip);
					return ip.ToString();
				}
			}
			return string.Empty;
		}
