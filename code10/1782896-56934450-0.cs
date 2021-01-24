    [assembly: FunctionsStartup(typeof(ServiceBus.Adapter.Startup))]
    namespace ServiceBus.Adapter {
    	public class Startup: FunctionsStartup {
    		public override void Configure(IFunctionsHostBuilder builder) {
    			builder.Services.AddHttpClient();
    		}
    	}
    }
