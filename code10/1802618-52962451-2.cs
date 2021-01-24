     public Startup(IHostingEnvironment env)
        {
           	 Configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();             
        }
		
	 public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
           ConnectionString = Configuration["ConnectionStrings:connectionstring"]; // Get Connection String from Appsetting.json
        }
