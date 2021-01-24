    public static Boolean SinglePackPing( MyConfig myConfig, String pingString )
    {
        Boolean ok = false;
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
        //Creates ServiceClient, attach transport-binding, Endpoint and the loaded certificate
        using( SinglePackServicesClient service = new SinglePackServicesClient( customTransportSecurityBinding, new EndpointAddress( endPoint ) ) )
        {
            using( X509Certificate2 cert = new X509Certificate2( myConfig.CertificateFilePath, myConfig.PrivateKeyPassword, X509KeyStorageFlags.PersistKeySet ) )
            {
                //Creates ServiceClient, attach transport-binding, Endpoint and the loaded certificate          
                service.ClientCredentials.ClientCertificate.Certificate = cert;
                service.Endpoint.EndpointBehaviors.Add( new CustomMessageInspector() );
                var bindingTest = service.Endpoint.Binding;
                //Creates PingRequest and set the ping Input
                SinglePackPingRequest ping = new SinglePackPingRequest();
                ping.Input = pingString;
                //Creates PingResponse, result of the request. Displays the response
                SinglePackPingResponse pingResponse = service.PingSinglePack(ping);
                ok = pingResponse.Output == pingString;
                //Displays the response. If the request is successful, the output is equal to the input
                Console.WriteLine( pingResponse.Output );
            }
        }
        return ok;
    }
