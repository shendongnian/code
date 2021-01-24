                public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
                {
                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Error");
                        app.UseHsts();
                    }
        
                    app.UseHttpsRedirection();
                    app.UseStaticFiles();
                    app.UseCookiePolicy();
        
                    app.UseMvc();
                    //Add this line of code
                    loggerFactory.AddApplicationInsights(app.ApplicationServices,LogLevel.Information);
                }
