    public class ServiceMessageServiceCredentialsInspector : IClientMessageInspector
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
    
                HttpRequestMessageProperty requestMessageProperty = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                requestMessageProperty.Headers[HttpRequestHeader.Authorization] = "Basic " +
                        Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
    
                return null;
            }
        }
