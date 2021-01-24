    [FunctionName("NewSbMessageArrivedFunction")]                    
    public static void Run(
        [ServiceBusTrigger("someQueue")] string queueMessage, TraceWriter log)
    {
        ...
    }
