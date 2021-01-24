    // Connect
    var hubConnection = new HubConnection("http://www.contoso.com/");
    IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("stockTicker");
    await hubConnection.Start();
    
    // Call server method "JoinGroup" from client
    stockTickerHubProxy.Invoke("JoinGroup", "SignalRChatRoom");
