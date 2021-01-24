    [assembly: FunctionsStartup(typeof(Namespace.Startup))]   
    
    namespace Namespace {    
    public class Startup : FunctionsStartup 
    {
        public override void Configure(IFunctionsHostBuilder builder) 
        {
            builder.Services.AddLogging(); 
        }
      }
    }
