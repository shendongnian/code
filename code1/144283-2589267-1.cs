    [XmlRoot("Response", Namespace="http://www.thirdparty.com/lr/")] 
    public class ResponseExt : Response { 
    } 
    [XmlRoot("Response", Namespace="http://www.thirdparty.com/lr/")] 
    public class Response { 
        public string Code {get; set;} 
        public string Message {get; set;} 
        public string SessionId {get; set;} 
    } 
