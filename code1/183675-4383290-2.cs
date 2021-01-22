    IConnectableObservable<char> keys = "ababc\tdabaababc\tebad"
        .ToObservable()
        .Publish();
    //`.Publish()` makes a cold observable become hot,
    // but you must call `Connect()` to start producing values.
    //insert above `matches` definition here.
    //insert above queries here.
    
    actions.Subscribe(a => a());
    
    keys.Connect();
