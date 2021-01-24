    [FunctionName("CancelEvent")] 
    public static void RunAsync([ServiceBusTrigger("canceleventqueue", AccessRights.Manage, Connection = "service_bus_key")]string myQueueItem, TraceWriter log, ExecutionContext context)
    {
        try
        {
            Processor.Process();
        }
        catch (Exception ex)
        {
            // Try catch will work fine 
        }
    }
    public class Processor
    {
        public static void Process()
        {
            // do the work
        }
    }
