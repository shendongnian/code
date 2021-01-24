    binding = new WebHttpBinding
    {
        TransferMode = TransferMode.Buffered,
        ReceiveTimeout = TimeSpan.FromMinutes(1),
        SendTimeout = TimeSpan.FromMinutes(1),
        MaxReceivedMessageSize = 2147483647,
        MaxBufferPoolSize = 2147483647,
        ReaderQuotas =
            {
                MaxDepth = 2147483647,
                MaxStringContentLength = 2147483647,
                MaxArrayLength = 2147483647,
                MaxBytesPerRead = 2147483647,
                MaxNameTableCharCount = 2147483647
            },
        Security = new WebHttpSecurity()
        {
            Mode = WebHttpSecurityMode.Transport,
            Transport = new HttpTransportSecurity()
            {
                ClientCredentialType = HttpClientCredentialType.Ntlm
            }
        }
    };
