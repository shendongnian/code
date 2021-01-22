    var message = "some message";
    var messageId = Guid.NewGuid().ToString();
    var factory = new ConnectionFactory { HostName = "localhost" };
    
    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
    	IBasicProperties props = channel.CreateBasicProperties();
    	props.MessageId = messageId;
    
    	byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);
    
        channel.BasicPublish("", "queueName", true, props, messageBodyBytes);
    }
