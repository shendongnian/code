    public class TMMessageInspector : IDispatchMessageInspector {
    
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext) {
                
                OperationContext.Current.Extensions.Add(new TMRequestContext());
                return null;
            }
    }
