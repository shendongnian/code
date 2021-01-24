    public class IdentityMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
            {
                var messageProperty = (HttpRequestMessageProperty)
                    OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name];
                string cookie = messageProperty.Headers.Get("Set-Cookie");
                if (cookie == null) // Check for another Message Header - SL applications
                {
                    cookie = messageProperty.Headers.Get("Cookie");
                }
                if (cookie == null)
                    cookie = string.Empty;
                //You can get the credentials from here, do something to them, on the service side
    }
