     public void Configuration(IAppBuilder app)
     {
        app.Map("/signalr", map =>
        {
          map.UseCors(CorsOptions.AllowAll);
          var hubConfiguration = new HubConfiguration { };
          map.RunSignalR(hubConfiguration);
        });
      }
