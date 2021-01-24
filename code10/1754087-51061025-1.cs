    namespace RestService
    {        
        [ServiceContract]
        public interface RestServiceWareHouse
        {
            
            [OperationContract]
            [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "/jsonUserList")]
            string JSONData();
        }
    }
    
