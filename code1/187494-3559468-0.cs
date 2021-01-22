    [ServiceContract]
    public class EchoService : IEchoService {
      [WebGet(UriTemplate="EchoMe?val={theValue}, ResponseFormat=WebMessageFormat.Json)]
      public string EchoMe(string theValue) {
        return theValue;
      }
    }
