      public class EnvelopeNamespaceMessage : Message
        {
            private readonly Message message;
    
            public string[] EnvelopeNamespaces { get; set; }
    
            public EnvelopeNamespaceMessage(Message message)
            {
                this.message = message;
            }
    
            public override MessageHeaders Headers
            {
                get { return this.message.Headers; }
            }
    
            public override MessageProperties Properties
            {
                get { return this.message.Properties; }
            }
    
            public override MessageVersion Version
            {
                get { return this.message.Version; }
            }
    
            protected override void OnWriteStartBody(XmlDictionaryWriter writer)
            {
                writer.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");
            }
    
            protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
            {
                this.message.WriteBodyContents(writer);
            }
    
            protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
            {
                writer.WriteStartElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
    
                if (EnvelopeNamespaces != null)
                {
                    foreach (string ns in EnvelopeNamespaces)
                    {
                        var tokens = ns.Split(new char[] { ':' }, 2);
                        writer.WriteAttributeString("xmlns", tokens[0], null, tokens[1]);
                    }
                }
            }
        }
    
        public class EnvelopeNamespaceMessageFormatter : IClientMessageFormatter
        {
            private readonly IClientMessageFormatter formatter;
    
            public string[] EnvelopeNamespaces { get; set; }
    
            public EnvelopeNamespaceMessageFormatter(IClientMessageFormatter formatter)
            {
                this.formatter = formatter;
            }
    
            public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
            {
                var message = this.formatter.SerializeRequest(messageVersion, parameters);
                return new EnvelopeNamespaceMessage(message) { EnvelopeNamespaces = EnvelopeNamespaces };
            }
    
            public object DeserializeReply(Message message, object[] parameters)
            {
                return this.formatter.DeserializeReply(message, parameters);
            }
        }
    
    
        [AttributeUsage(AttributeTargets.Method)]
        public class EnvelopeNamespacesAttribute : Attribute, IOperationBehavior
        {
            public string[] EnvelopeNamespaces { get; set; }
    
            public void AddBindingParameters(OperationDescription operationDescription,
                BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            {
                //var serializerBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                IOperationBehavior serializerBehavior = operationDescription.Behaviors.Find<XmlSerializerOperationBehavior>();
                if (serializerBehavior == null)
                    serializerBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
    
                if (clientOperation.Formatter == null)
                    serializerBehavior.ApplyClientBehavior(operationDescription, clientOperation);
    
                IClientMessageFormatter innerClientFormatter = clientOperation.Formatter;
                clientOperation.Formatter = new EnvelopeNamespaceMessageFormatter(innerClientFormatter)
                {
                    EnvelopeNamespaces = EnvelopeNamespaces
                };
            }
    
            public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
            }
    
            public void Validate(OperationDescription operationDescription)
            {
            }
        }
