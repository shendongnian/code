    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, SalesModelBuilder modelBuilder)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMvc(routeBuilder =>
            {
                routeBuilder.Expand().Select();
                routeBuilder.MapODataServiceRoute("ODataRoutes", "odata",
                        modelBuilder.GetEdmModel(app.ApplicationServices));
            });
    }
