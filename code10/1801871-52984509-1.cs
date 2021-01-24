      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Authorization Middleware
            app.UseMiddleware<AuthenticationMiddleware>();
         //   Other Middleware will come here
            app.UseMvc();
            
           
        }
    }
