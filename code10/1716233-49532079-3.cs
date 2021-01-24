    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider) {
    
        //Code removed for brevity
        
        var urlHelper = serviceProvider.GetService<IUrlHelper>(); <-- helper instance
    
        app.UseMvc();
    }
