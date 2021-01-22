    [ServiceContract]
    public class Service
    {        
        [OperationContract]
        [WebInvoke(UriTemplate = "{param0}/{param1}", Method = "POST")]
        public Stream TestPost(string param0, string param1)
        {
            
            string body = Encoding.UTF8.GetString(OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>());
            
            return ...;
        }
    }
