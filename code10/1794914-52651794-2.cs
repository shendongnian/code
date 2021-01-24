     public void ConfigureServices (IServiceCollection services) {
            
            services.AddScoped<DbContext, Your_Project_DbContext> ();
            services.AddScoped<Your_Interface, Your_Concrete_Class> ();
        }
