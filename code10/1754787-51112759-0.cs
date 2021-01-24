	public static class CheckRemoteHost
	{
		public static IList<string> Ping(HashSet<string> IP_Ports, int TimeoutInMS = 100)
		{
			var query =
				from host in IP_Ports.ToObservable()
				from status in Observable.FromAsync(() => PingAsync(host, TimeoutInMS))
				where status
				select host;
	
			return query.ToList().Wait();
		}
	
		private static async Task<bool> PingAsync(string ip, int timeout)
		{
			try
			{
				var ping = new System.Net.NetworkInformation.Ping();
				var reply = await ping.SendPingAsync(ip, timeout);
	
				return reply.Status == System.Net.NetworkInformation.IPStatus.Success;
			}
			catch
			{
				return false;
			}
		}
	}
