            services.AddSingleton<IClaimsTransformation, ClaimsLoader>();
            services.AddTransient<IUserrolesRepository, EFUserrolesRepository>();
            services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
 
    services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);
