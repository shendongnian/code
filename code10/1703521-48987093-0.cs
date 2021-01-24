    public void Configure(IApplicationBuilder app, IHostingEnvironment env, StoreContext context )
    {
        ...
        //After app.UseMvc()
        StoreInitializer.Initialize(context);
    }
