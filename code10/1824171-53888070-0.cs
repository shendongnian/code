    public void DeferProcessingToServiceBus(IncomingSlackRequestModel incomingSlackRequestModel)
    {
        var serializedModel = JsonConvert.SerializeObject(incomingSlackRequestModel);
        var sbConnectionString = ConfigurationManager.AppSettings.Get("SERVICE_BUS_CONNECTION_STRING");
        var sbQueueName = ConfigurationManager.AppSettings.Get("OpsNotificationsQueueName");
        var client = QueueClient.CreateFromConnectionString(sbConnectionString, sbQueueName);
        var brokeredMessage = new BrokeredMessage(serializedModel);
        client.Send(brokeredMessage);
    }
