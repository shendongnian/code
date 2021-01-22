        public class MyPolicy : SoapFilter
        {
            public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
            {
                // Remove all WS-Addressing and WS-Security header info
                envelope.Header.RemoveAll();
    
                return SoapFilterResult.Continue;
            }
        }
    
        public class MyAssertion : PolicyAssertion
        {
            public override SoapFilter CreateClientInputFilter(FilterCreationContext context)
            {
                return null;
            }
    
            public override SoapFilter CreateClientOutputFilter(FilterCreationContext context)
            {
                return new MyPolicy();
            }
    
            public override SoapFilter CreateServiceInputFilter(FilterCreationContext context)
            {
                return null;
            }
    
            public override SoapFilter CreateServiceOutputFilter(FilterCreationContext context)
            {
                return null;
            }
        }
