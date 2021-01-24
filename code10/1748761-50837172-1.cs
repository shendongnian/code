    static async Task Main(string[] args)
    {
        var connectionFactory = new ConnectionFactory(DispatchConsumersAsync = true);
        var connection = connectionFactory.CreateConnection();
        var channel = connection.CreateModel();
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;
    }
    static async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
    {
        await DoSomethingAsync();
    }
