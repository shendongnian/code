	public class Service1 : IService1
	{
		public string GetData(int value)
		{
			// send msg to clients
			var hub = GlobalHost.ConnectionManager.GetHubContext<ServiceMonitorHub>();
			hub.Clients.All.BroadcastMessage();
			return string.Format("You entered: {0}", value);
		}
