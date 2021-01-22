    public class WebContentTypeAttribute : Attribute, IOperationBehavior, IDispatchMessageFormatter
    {
        private IDispatchMessageFormatter innerFormatter;
        public string ContentTypeOverride { get; set; }
    	
        public WebContentTypeAttribute(string contentTypeOverride)
    	{
            this.ContentTypeOverride = contentTypeOverride;
    	}
    
    
        // IOperationBehavior
        public void Validate(OperationDescription operationDescription)
        {
            
        }
    
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            innerFormatter = dispatchOperation.Formatter;
            dispatchOperation.Formatter = this;
        }
    
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            
        }
    
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            
        }
    
        // IDispatchMessageFormatter
        public void DeserializeRequest(Message message, object[] parameters)
        {
            if (message == null)
                return;
    
            if (string.IsNullOrEmpty(ContentTypeOverride))
                return;
    
            var httpRequest = (HttpRequestMessageProperty)message.Properties[HttpRequestMessageProperty.Name];
            httpRequest.Headers["Content-Type"] = ContentTypeOverride;
        }
    
        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            return innerFormatter.SerializeReply(messageVersion, parameters, result);
        }
    }
