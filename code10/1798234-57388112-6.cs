    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IFileService FileService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //dont change the below order as middleware exception need to be registered before UseMvc method register
            app.ConfigureCustomMiddleware();
            // app.UseHttpsRedirection();
            app.UseMvc();
            FileService.CreateDirectoryStructure();
        }
