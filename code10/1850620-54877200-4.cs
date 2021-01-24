    [assembly: FunctionsStartup(typeof(MyNamespace.Startup))]    
    namespace MyNamespace {
        public class Startup : FunctionsStartup {
            public override void Configure(IFunctionsHostBuilder builder) {
                //  ** Registers the ILogger instance **
                builder.Services.AddLogging();
                
                //  Registers the application settings' class.
                //...
    
                //...omitted for brevity    
            }
        }
    }
