    public abstract class AuthenticateRequest
    {    
        public abstract HttpContent GetContent();
    } 
    
    public class SoapAuthenticateRequest : AuthenticateRequest
    {
        public override HttpContent GetContent()
        {
            // your logic
    
            return new StringContent(soap, Encoding.UTF8, ContentTypes.XmlSoap);
        }
    }
    
    public class JsonAuthenticateRequest : AuthenticateRequest
    {
        public override HttpContent GetContent()
        {
            var json = JsonConvert.SerializeObject(ParameterKeyValues);
            return new StringContent(json, Encoding.UTF8, ContentTypes.Json);
        }
    }
