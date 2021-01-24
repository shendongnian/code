         public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ContractResolver =
                        new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });
                
                services.AddOData();
          //etc
            }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    	{
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
     
        var builder = new ODataConventionModelBuilder(app.ApplicationServices));           
        builder.EntitySet<Test>(nameof(Test));
         
        app.UseMvc(routebuilder =>
        {
            routebuilder.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        });
     
        app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly,
            settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });           
        app.UseMvc();
        //etc
     }
