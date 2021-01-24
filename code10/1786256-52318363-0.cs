    namespace System.ServiceModel
    {
        public class BasicHttpBinding : HttpBindingBase
        {
            public BasicHttpBinding();
            public BasicHttpBinding(BasicHttpSecurityMode securityMode);
    
            public BasicHttpSecurity Security { get; set; }
    
            public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingParameterCollection parameters);
            public override BindingElementCollection CreateBindingElements();
        }
    }
