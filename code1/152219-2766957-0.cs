    public class ConsoleOutputMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
             Console.WriteLine("Starting call");
             // count++ here
             return null;
        }
    
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            // count-- here
            Console.WriteLine("Returning");
        }
    }
