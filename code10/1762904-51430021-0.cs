    consumer.Received += OnReceived;
    
    ....
    private static void OnReceived(object model, BasicDeliverEventArgs e)
    {
        var body = ea.Body;
        var message = Encoding.UTF8.GetString(body);
        // At this point, I can do something with the message.
    }
