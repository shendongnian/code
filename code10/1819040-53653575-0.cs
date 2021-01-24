        string endPoint = myConfig.SinglePackServicesEndPoint;
        //Defines a secure binding with certificate authentication
        WSHttpBinding binding = new WSHttpBinding();
        binding.Security.Mode = SecurityMode.Transport;
        binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
        // create a new binding based on the existing binding
        var customTransportSecurityBinding = new CustomBinding( binding );
        // locate the TextMessageEncodingBindingElement - that's the party guilty of the inclusion of the "To"
        var ele = customTransportSecurityBinding.Elements.FirstOrDefault( x=>x is TextMessageEncodingBindingElement );
        if( ele != null )
        {
            // and replace it with a version with no addressing
            // replace {Soap12 (http://www.w3.org/2003/05/soap-envelope) Addressing10 (http://www.w3.org/2005/08/addressing)}
            //    with {Soap12 (http://www.w3.org/2003/05/soap-envelope) AddressingNone (http://schemas.microsoft.com/ws/2005/05/addressing/none)}
            int index = customTransportSecurityBinding.Elements.IndexOf( ele );
            var textBindingElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };
            customTransportSecurityBinding.Elements[index] = textBindingElement;
        }
