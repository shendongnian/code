    [FunctionName("ServiceBusQueueTriggerCSharp")]                    
    public static void Run(
        [ServiceBusTrigger("myqueue", AccessRights.Manage, Connection = "ServiceBusConnection")] 
        string myQueueItem,
        Int32 deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        TraceWriter log)
    {
        log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        log.Info($"EnqueuedTimeUtc={enqueuedTimeUtc}");
        log.Info($"DeliveryCount={deliveryCount}");
        log.Info($"MessageId={messageId}");
    }
