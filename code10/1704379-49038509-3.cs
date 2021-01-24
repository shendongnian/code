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
			//...call the unity config related code.
		    var container = UnityConfig.Container;
			//...any other code to populate container.
			
			return container;
		}
	}
	
