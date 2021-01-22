    public class MyServiceMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
             string url = request.Headers.To;
    
             return null;
        }
    }
