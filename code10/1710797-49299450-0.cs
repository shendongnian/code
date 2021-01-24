	public void ConfigureServices(IServiceCollection services) {
	    //...
	
		// Setup options with DI
		services.AddOptions();
		// Configure EtimeSettingsModel using config by installing 
		// Microsoft.Extensions.Options.ConfigurationExtensions
		// Bind options using a sub-section of the appsettings.json file.
		services.Configure<EtimeSettingsModel>(Configuration.GetSection("EtimeSettings"));
		services.AddMvc();
		
	    //...		
	}
