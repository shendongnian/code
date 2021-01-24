    public void ConfigureServices(IServiceCollection services)
    {
    	var mvcConfig = new MvcConfig
    	{
    		Formatting = Newtonsoft.Json.Formatting.Indented
    	};
    	
    	services.AddMvc()
    			.AddWebApiConventions()
    			.AddJsonOptions(options=> options.SerializerSettings.Formatting=mvcConfig.Formatting);
    			
    	services.AddSingleton(mvcConfig);
    }
