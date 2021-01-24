    private Binding GetBinding()
    {
        var binding = new CustomBinding()
        // This could be configured per service
        MessageVersion messageVersion = MessageVersion.Soap12;
    
        TextMessageEncodingBindingElement messageEncodingElement = new TextMessageEncodingBindingElement(messageVersion, Encoding.UTF8);
        binding.Elements.Add(messageEncodingElement)
        if (/* Encryption is needed */)
        {
            SecurityBindingElement securityElement = securityElement = SecurityBindingElement.CreateAnonymousForCertificateBindingElement();
            securityElement.DefaultAlgorithmSuite = GetEncryptionAlgorithm(); // This will return which algorithm is desired
            securityElement.IncludeTimestamp = false; // This is because our services were returning an error when it was included
            binding.Elements.Add(securityElement);
    
        HttpsTransportBindingElement httpsTransportElement = new HttpsTransportBindingElement()
        if (/* If Windows Authentication is required */)
            httpsTransportElement.AuthenticationScheme = AuthenticationSchemes.Negotiate;
        binding.Elements.Add(httpsTransportElement)
        return binding;
    }
