            WebHttpBinding binding2 = new WebHttpBinding();
            XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas();
            myReaderQuotas.MaxStringContentLength = 2147483647;
            myReaderQuotas.MaxArrayLength = 2147483647;
            myReaderQuotas.MaxBytesPerRead = 2147483647;
            myReaderQuotas.MaxDepth = 2147483647;
            myReaderQuotas.MaxNameTableCharCount = 2147483647;
            binding2.GetType().GetProperty("ReaderQuotas").SetValue(binding2, myReaderQuotas, null);
            binding2.MaxBufferSize = 2147483647;
            binding2.MaxReceivedMessageSize = 2147483647;
            ServiceEndpoint ep = new ServiceEndpoint(ContractDescription.GetContract(typeof(IMyService)),
                binding2, new EndpointAddress("http://localhost:9000/MyService"));
            
            WebChannelFactory<IMyService> cf2 = new WebChannelFactory<IMyService>(ep);
            IMyService serv = cf2.CreateChannel();
            serv.PrintNameDesc("Ram", new string('a', 100*1024*1024));
