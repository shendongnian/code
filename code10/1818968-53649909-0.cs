    Dictionary<string, object> headers = new Dictionary<string, object>();
    headers("type", "type1");
    
    IBasicProperties basicProperties = model.CreateBasicProperties();
    basicProperties.Headers = headers;
    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
    model.BasicPublish(_headersExchange, "", basicProperties, messageBytes);
