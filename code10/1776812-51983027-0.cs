    public static void Main(string[] args)
    {
    	ConnectionFactory factory = new ConnectionFactory();
    	factory.UserName = "guest";
   		factory.Password = "guest";
    	factory.HostName = "localhost";
    	factory.VirtualHost = "/";
    
    	var connection = factory.CreateConnection();
    	var channel = connection.CreateModel();
       
    	var queueName = "test-queue";
    	channel.QueueDeclare(queueName, false, false, false, null);
    	channel.QueueBind(queueName, "example.exchange", "", null);
    
    	var consumer = new EventingBasicConsumer(channel);
    	consumer.Received += (model, ea) =>
    	{
    		var bodyy = ea.Body;
    		var messagee = Encoding.UTF8.GetString(bodyy);
    		Console.WriteLine("received [x] {0}", messagee);
    	};
    	channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    
    	Console.ReadLine();
    }
