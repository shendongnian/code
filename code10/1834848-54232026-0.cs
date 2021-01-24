	[assembly: OwinStartup(typeof(YourNamespace.SignalRStartup))]
	namespace YourNamespace
	{
		public class SignalRStartup
		{
			public void Configuration(IAppBuilder app)
			{
				app.MapSignalR();
			}
		}
	}
