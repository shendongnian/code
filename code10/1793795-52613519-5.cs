    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
         if (env.IsDevelopment())
         {
             app.UseDeveloperExceptionPage();
         }
    
         app.Use(async (context, next) =>
         {
             // Forward to the next one.
             await next.Invoke();
         });
    
         // !! Have to be called after setting up middleware !!
         app.UseMvc();
    }
