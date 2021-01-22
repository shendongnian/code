    var messageId = "id";
    var factory = new ConnectionFactory { HostName = "localhost" };
    
    using (var connection = _factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
    	var queueDeclareResponse = channel.QueueDeclare("queueName", true, true, false, null);
    
    	for (int i = 0; i < queueDeclareResponse.MessageCount; i++)
    	{
    		var result = channel.BasicGet("queueName", false);
    		var id = result.BasicProperties.MessageId;
    
    		if (id == messageId)
    		{
    			var body = result.Body;
    			var message = Encoding.UTF8.GetString(body);
    
    			//Do something with the message
    
    			channel.BasicAck(result.DeliveryTag, false);
    			break;
    		}
    	}
    }
