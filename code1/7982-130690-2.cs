    public class AuthenticationSoapExtension : SoapExtension
    {
        private ServiceAuthHeader authHeader;
    
        public AuthenticationSoapExtension()
        {
        }
    
        public override object GetInitializer(Type serviceType)
        {
            return null;
        }
    
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
    
        public override void Initialize(object initializer)
        {        
        }
    
        public override void ProcessMessage(SoapMessage message)
        {
            if (message.Stage == SoapMessageStage.AfterDeserialize)
            {
                foreach (SoapHeader header in message.Headers)
                {
                    if (header is ServiceAuthHeader)
                    {
                        authHeader = (ServiceAuthHeader)header;
    
                        if(authHeader.Password == TheCorrectUserPassword)
                        {
                            return;  //confirmed
                        }
                    }
                }
    
                throw new SoapException("Unauthorized", SoapException.ClientFaultCode);
            }
        }
    }
