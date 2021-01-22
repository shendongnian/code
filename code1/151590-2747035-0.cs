    [MessageContract]
    public class YourMessageType
    {
      // This is in the SOAP Header
      [MessageHeader] public string UserName {get;set;}
      [MessageHeader] public string Password {get;set;}
    
      // This is in the SOAP body
      [MessageBodyMember] public string OtherData {get;set;}
      ...
    }
