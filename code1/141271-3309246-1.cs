    [MessageContract]
    public class MyCustomResponse
    {
        [MessageBodyMember(Namespace = "http://MyNamespace")]
        public string Response { get; set; }
    }
        
