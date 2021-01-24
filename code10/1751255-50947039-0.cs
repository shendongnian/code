    public Task<int> RequestAccepted()
    {
        bool SearchingPartner= true;
        int PartnerId = 0;
        var connectionFactory = new ConnectionFactory()
        {
            // credentials
        };
        IConnection connection = connectionFactory.CreateConnection();
        IModel channel = connection.CreateModel();
        channel.BasicQos(0, 1, false);
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        var eventingBasicConsumer = new EventingBasicConsumer(channel);
        eventingBasicConsumer.Received += (sender, basicDeliveryEventArgs) =>
        {
             string Response = Encoding.UTF8.GetString(basicDeliveryEventArgs.Body, 0, basicDeliveryEventArgs.Body.Length);
             channel.BasicAck(basicDeliveryEventArgs.DeliveryTag, false);
             if(!string.IsNullOrWhiteSpace(Response))
             {
                 int Id = Convert.ToInt32(Response);
                 PartnerId = Id > 0 ? Id : 0;
                 SearchingPartner = false;
                 tcs.SetResult( PartnerId );
             }
        };
        channel.BasicConsume("SolicitacaoAceitaSameDay", false, eventingBasicConsumer);
        return tcs.Task;
    }
