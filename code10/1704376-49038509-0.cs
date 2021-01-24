	public class Startup{    
		public void Configuration(IAppBuilder app) {
			IUnityContainer container = GetContainer();	
			
			var resolver = new UnitySignalRDependencyResolver(container);
			var config = new HubConfiguration {
				Resolver = resolver
			};		
			app.MapSignalR("/signalr", config);
		}
		
		IUnityContainer GetContainer() {
			//...code to populate container.
			//...call the unity config related code.
		}
	}
