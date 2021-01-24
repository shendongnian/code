            [FunctionName("DelayMessage")]
            public static async Task DelayMessage(
                [ServiceBusTrigger("MyQueue", AccessRights.Listen, Connection = "MyConnection")]BrokeredMessage originalMessage,
                [ServiceBus("MyQueue", AccessRights.Send, Connection = "MyConnection")]IAsyncCollector<BrokeredMessage> newMessages,
                TraceWriter log)
            {
                //handle any kind of error scenerio
                var newMessage = originalMessage.Clone();
    
                newMessage.ScheduledEnqueueTimeUtc = DateTime.UtcNow.AddMinutes(5);
    
                await newMessages.AddAsync(newMessage);
    
            }
