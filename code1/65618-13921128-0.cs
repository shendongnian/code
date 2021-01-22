    //Add a metadata endpoint at each base address
    //using the "/mex" addressing convention
    foreach (Uri baseAddress in this.BaseAddresses)
    {
        if (baseAddress.Scheme == Uri.UriSchemeHttp)
        {
            mexBehavior.HttpGetEnabled = true;
            this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                    MetadataExchangeBindings.CreateMexHttpBinding(),
                                    "mex");
        }
        else if (baseAddress.Scheme == Uri.UriSchemeHttps)
        {
            mexBehavior.HttpsGetEnabled = true;
            this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                    MetadataExchangeBindings.CreateMexHttpsBinding(),
                                    "mex");
        }
        else if (baseAddress.Scheme == Uri.UriSchemeNetPipe)
        {
            this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                    MetadataExchangeBindings.CreateMexNamedPipeBinding(),
                                    "mex");
        }
        else if (baseAddress.Scheme == Uri.UriSchemeNetTcp)
        {
            this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                    MetadataExchangeBindings.CreateMexTcpBinding(),
                                    "mex");
        }
    }
