        public void ConfigureServices(IServiceCollection services)
        {
    
            if (Configuration["settings:connectionString"] == null)
            {
                 // Log?
                 System.Environment.Exit(160);
            }
    
       }
