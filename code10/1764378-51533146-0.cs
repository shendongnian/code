    EventHubClient eventHubClient;
    var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
    {
         EntityPath = EventHubName
    };
    eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
