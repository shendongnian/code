    protected void Button1_Click(object sender, EventArgs e)
    {
        //Set the hubs URL for the connection
        string url = "http://localhost:8080/signalr";
        // Declare a proxy to reference the hub.
        var connection = new HubConnection(url);
        var _hub = connection.CreateHubProxy("MyHub");
        connection.Start().Wait();
            
        _hub.Invoke("SendMessage", "$").Wait();
    }
