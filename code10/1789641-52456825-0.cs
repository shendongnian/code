    // open the client's connection
            private static DocumentClient client = new DocumentClient(
                new Uri(endpoint),authKey,
                new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp });
    
    [FunctionName("Search")]
