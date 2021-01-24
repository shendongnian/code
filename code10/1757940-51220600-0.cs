    [FunctionName("Function1")]
    [return: Queue("myqueue-output", Connection = "")]
    public static async Task<string> Run([QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, TraceWriter log)
    {
        await Task.Delay(1000);
        log.Info($"C# Queue trigger function processed: {myQueueItem}");
        return new string(myQueueItem.Reverse().ToArray());
    }
