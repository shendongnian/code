    [FunctionName("FunctionB")]                    
    public static void Run(
        [ServiceBusTrigger("myqueue", AccessRights.Manage, Connection = "ServiceBusConnection")] 
        string myQueueItem, 
        TraceWriter log)
    {
        log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        MethodB();
    }
