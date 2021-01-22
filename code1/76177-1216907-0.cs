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
        private Regex ActionRegex = new Regex("\w+:\/\/.+/(?<action>.+)");
    
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var operation = GetOperation(request.Headers.Action);
            var timeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var toSign = operation + timeStamp;
            var toSignBytes = Encoding.UTF8.GetBytes(toSign);
            var secretBytes = Encoding.UTF8.GetBytes(Helpers.AWSSecretKey);
            var signer = new HMACSHA256(secretBytes);
            var sigBytes = signer.ComputeHash(toSignBytes);
            var signature = Convert.ToBase64String(sigBytes);
    
            request.Headers.Add(new CustomAmazonHeader("AWSAccessKeyId", Helpers.NameSpace, Helpers.AWSAccessKeyId));
            request.Headers.Add(new CustomAmazonHeader("Timestamp", Helpers.NameSpace, timeStamp));
            request.Headers.Add(new CustomAmazonHeader("Signature", Helpers.NameSpace, signature));
    
            return null;
        }
    
        private string GetOperation(string request)
        {
            var match = ActionRegex.Match(request);
            var action= match.Groups["action"];
            return action.Value;
        }
    }
    
    
    public class CustomAmazonHeader : MessageHeader
    {
        private readonly string name;
    
        private readonly string namespace;
    
        public CustomAmazonHeader(string name, string namespace, string value)
        {
            this.name = name;
            this.namespace = namespace;
            Value = value;
        }
    
        public override string Name
        {
            get { return name; }
        }
    
        public override string Namespace
        {
            get { return namespace; }
        }
    
        private string Value { get; set; }
    
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteElementString("aws", Name, Namespace, Value);
        }
    }
