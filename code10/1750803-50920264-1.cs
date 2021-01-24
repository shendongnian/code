     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
                //authentication added 
                app.UseAuthentication();
    
                app.UseCors("Cors");
                app.UseMvc();
            }
