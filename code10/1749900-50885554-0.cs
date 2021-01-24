    [FunctionName("CancelEvent")] 
    public static async Task RunAsync([ServiceBusTrigger("canceleventqueue", AccessRights.Manage, Connection = "service_bus_key")]string myQueueItem, TraceWriter log, ExecutionContext context)
    {
        try
        {
            await Processor.ProcessAsync();
        }
        catch (Exception ex)
        {
            // Try catch will work fine 
        }
    }
    public class Processor
    {
        public static async Task ProcessAsync()
        {
            // do the work
        }
    }
