        public void ConfigureServices(IServiceCollection services)
        {
        	services.AddMvc();
    
        	Configuration.Bind("Routing", MyRouteAttribute.RouteConfiguration);
        }
