    app.Use(next => (context) =>
    {
        var hubContext = (IHubContext<MyHub>)context
                            .RequestServices
                            .GetServices<IHubContext<MyHub>>();
        //...
    });
