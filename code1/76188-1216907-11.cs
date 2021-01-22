    public class SigningExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(SigningBehavior); }
        }
    
        [ConfigurationProperty("actionPattern", IsRequired = true)]
        public string ActionPattern
        {
            get { return this["actionPattern"] as string; }
            set { this["actionPattern"] = value; }
        }
    
        [ConfigurationProperty("algorithm", IsRequired = true)]
        public string Algorithm
        {
            get { return this["algorithm"] as string; }
            set { this["algorithm"] = value; }
        }
    
        [ConfigurationProperty("algorithmKey", IsRequired = true)]
        public string AlgorithmKey
        {
            get { return this["algorithmKey"] as string; }
            set { this["algorithmKey"] = value; }
        }
    
        protected override object CreateBehavior()
        {
            var hmac = HMAC.Create(Algorithm);
            if (hmac == null)
            {
                throw new ArgumentException(string.Format("Algorithm of type ({0}) is not supported.", Algorithm));
            }
    
            if (string.IsNullOrEmpty(AlgorithmKey))
            {
                throw new ArgumentException("AlgorithmKey cannot be null or empty.");
            }
    
            hmac.Key = Encoding.UTF8.GetBytes(AlgorithmKey);
    
            return new SigningBehavior(hmac, ActionPattern);
        }
    }
    
    public class SigningBehavior : IEndpointBehavior
    {
        private HMAC algorithm;
    
        private string actionPattern;
    
        public SigningBehavior(HMAC algorithm, string actionPattern)
        {
            this.algorithm = algorithm;
            this.actionPattern = actionPattern;
        }
    
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
            clientRuntime.MessageInspectors.Add(new SigningMessageInspector(algorithm, actionPattern));
        }
    }
    
    public class SigningMessageInspector : IClientMessageInspector
    {
        private readonly HMAC Signer;
    
        private readonly Regex ActionRegex;
    
        public SigningMessageInspector(HMAC algorithm, string actionPattern)
        {
            Signer = algorithm;
            ActionRegex = new Regex(actionPattern);
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
