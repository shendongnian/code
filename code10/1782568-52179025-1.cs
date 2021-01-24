    [FunctionName("DelayMessage")]
    public static async Task DelayMessage([ServiceBusTrigger("MyQueue", AccessRights.Listen, Connection = "MyConnection")]BrokeredMessage originalMessage,
                [ServiceBus("MyQueue", AccessRights.Send, Connection = "MyConnection")]IAsyncCollector<BrokeredMessage> newMessages,TraceWriter log)
    {
         //handle any kind of error scenerio
         int resubmitCount = originalMessage.Properties.ContainsKey("ResubmitCount") ?  (int)originalMessage.Properties["ResubmitCount"] : 0;
         if (resubmitCount > 5)
         {
             Console.WriteLine("DEAD-LETTERING");
             originalMessage.DeadLetter("Too many retries", $"ResubmitCount is {resubmitCount}");
         }
         else
         {
             var newMessage = originalMessage.Clone();
             newMessage.ScheduledEnqueueTimeUtc = DateTime.UtcNow.AddMinutes(5);
             await newMessages.AddAsync(newMessage);
         }
    }
