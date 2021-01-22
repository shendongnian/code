    public class SigningBehavior : IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new CustomMessageInspector());
        }
    }
    
    
    public class CustomMessageInspector : IClientMessageInspector
    {
        private static readonly HMAC Signer;
        private static readonly Regex ActionRegex = new Regex(@"\w:\/\/.+/(?<action>.+)");
        static CustomMessageInspector()
        {
            var secretBytes = Encoding.UTF8.GetBytes(Helpers.AWSSecretKey);
            Signer = new HMACSHA256(secretBytes);
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var operation = GetOperation(request.Headers.Action);
            var timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var toSignBytes = Encoding.UTF8.GetBytes(operation + timeStamp);
            var sigBytes = Signer.ComputeHash(toSignBytes);
            var signature = Convert.ToBase64String(sigBytes);
            request.Headers.Add(MessageHeader.CreateHeader("AWSAccessKeyId", Helpers.NameSpace, Helpers.AWSAccessKeyId));
            request.Headers.Add(MessageHeader.CreateHeader("Timestamp", Helpers.NameSpace, timeStamp));
            request.Headers.Add(MessageHeader.CreateHeader("Signature", Helpers.NameSpace, signature));
            return null;
        }
        private string GetOperation(string request)
        {
            var match = ActionRegex.Match(request);
            var val = match.Groups["action"];
            return val.Value;
        }
    }
