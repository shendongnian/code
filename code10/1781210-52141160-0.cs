    [assembly: WebJobsStartup(typeof(WebJobsExtensionStartup ), "A Web Jobs Extension Sample")]
    namespace ExtensionSample
    {
        public class WebJobsExtensionStartup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {
                 //Don't need to create a new service collection just use the built-in one
                 builder.Services.AddSingleton<CustomType>();                 
                 //Registering an extension
                 builder.AddExtension<InjectConfiguration>(); 
            }
        } 
    }
