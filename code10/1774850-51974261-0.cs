    BasicHttpBinding binding = new BasicHttpBinding()
    {
        Namespace = "WebServices.CA_ServiceSoap",
        CloseTimeout = new TimeSpan(0, 1, 0),
        OpenTimeout = new TimeSpan(0,1,0),
        ReceiveTimeout = new TimeSpan(0,10,0),
        SendTimeout = new TimeSpan(0,1,0),
        AllowCookies = false,
        BypassProxyOnLocal = false,
        HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
        MaxBufferSize = 1000000,
        MaxBufferPoolSize = 524288,
        MaxReceivedMessageSize = 1000000,
        MessageEncoding = WSMessageEncoding.Text,
        TextEncoding = Encoding.UTF8,
        TransferMode = TransferMode.Buffered,
        UseDefaultWebProxy = true,
        ReaderQuotas = new XmlDictionaryReaderQuotas()
        {
            MaxDepth = 32,
            MaxStringContentLength = 16384,
            MaxArrayLength = 16384,
            MaxBytesPerRead = 4096,
            MaxNameTableCharCount = 16384
        }
    };
    binding.Security.Mode = BasicHttpSecurityMode.Transport;
    binding.Security.Transport = new HttpTransportSecurity()
    {
        ClientCredentialType = HttpClientCredentialType.None,
        ProxyCredentialType = HttpProxyCredentialType.None,
        Realm = ""
    };
    binding.Security.Message = new BasicHttpMessageSecurity()
    {
        ClientCredentialType = BasicHttpMessageCredentialType.UserName,
        AlgorithmSuite = SecurityAlgorithmSuite.Default
    };
    client = new CA_ServiceSoapClient(binding, new EndpointAddress(Config.WebServiceURL));
