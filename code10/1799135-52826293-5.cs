    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        var myClass = app.ApplicationServices.GetService<MyClass>();
        myClass.InitializeServers();
        // the rest of the startup
        ...
    }
