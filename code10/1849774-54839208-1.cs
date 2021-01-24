    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }
    
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();
    
    
                app.Use(async (context, next) =>
                {
                    if (context.Request.Path == "/")
                    {
                        context.Response.Redirect("Home/Index", true);
                    }
                    await next();
                });
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "Index",
                        template: "{controller=Home}/{action=Index}");
                });
            }
