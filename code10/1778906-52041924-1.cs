    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            
            //app.UseHttpsRedirection();
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyHeader()
                                                   .AllowAnyMethod()
                                                   .AllowCredentials()
            );
            app.UseMvc();
        }
