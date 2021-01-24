    public void ConfigureServices(IServiceCollection services)
    {
       services.AddFirebaseAuthentication(Configuration["FirebaseAuthentication:Issuer"], Configuration["FirebaseAuthentication:Audience"]);
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
       app.UseAuthentication();
    }
