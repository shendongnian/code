    static async Task Receive(ITdlMessageReceiver receiver, ILogger logger) {
        while (true) {
            var message = await receiver.ReceiveAsync<TdlMessage<object>>(topic, entity);
            if (message != null) {
                logger.LogDebug($"Message received. Topic: {topic}. Action: {Enum.GetName(typeof(TopicActions), message.Action)}. Message: {JsonConvert.SerializeObject(message)}.");    
            }    
            await Task.Delay(sleepTime);
        }
    }
