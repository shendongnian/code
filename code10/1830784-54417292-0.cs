    public void ConfigureServices(IServiceCollection colllection){
         collection.AddSingleton<Sender>();
         collection.AddSingleton<Receiver>();
     }
     public void Configure(IApplicationBuilder app)
     {
        app.UseWebsockets();
        app.UseMiddleware<DispatcherMiddleware>(); //receives socket here
      
     }
