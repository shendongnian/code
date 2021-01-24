    protected async override void OnShown(EventArgs e)
    {
        base.OnShown(e);
    
        hubConnection = new HubConnection("myhubsurl");
        hubProxy = hubConnection.CreateHubProxy("SecondHub");
    
        doWork = hubProxy.On<IEnumerable<Item>>("DoWork", items => WorkOnItems(items));
    
        await hubConnection.Start();
    }
