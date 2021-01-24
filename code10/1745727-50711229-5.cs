    [FunctionName("ServiceBusQueueFunction")]
    public static void Run([ServiceBusTrigger("taskqueue", Connection = "ServiceBusConnectionString")] Message message, TraceWriter log)
    {
    	Customer customer = JsonConvert.DeserializeObject<Customer>(Encoding.UTF8.GetString(message.Body));
    }
