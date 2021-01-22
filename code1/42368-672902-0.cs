    public void PublishMessage(string message)
    {
        ConnectionFactory factory = new ConnectionFactory();
        factory.Parameters.VirtualHost = "/localhost";
        IProtocol protocol = Protocols.AMQP_0_8_QPID;
        using (IConnection conn = factory.CreateConnection(protocol, "localhost", 5672))
        {
            using (IModel ch = conn.CreateModel())
            {
                ch.ExchangeDeclare("test.direct", "direct");
                ch.QueueDeclare("test-queue");
                ch.QueueBind("test-queue", "test.direct", "TEST", false, null);
                ch.BasicPublish("test.direct", "TEST", null, Encoding.UTF8.GetBytes(message));
            }
        }
    }
