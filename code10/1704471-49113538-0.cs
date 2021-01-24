    public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                var options = new RewriteOptions();
                options.Rules.Add(new NonWwwRule());
                app.UseRewriter(options);
                app.UseStaticFiles();
                
                app.UseMvc();
            }
  
