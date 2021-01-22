        [TestMethod]
        [Timeout(2000)]
        public void ApiClientTest()
        {
            bool ApiSuccessSet, ClientSuccessSet = ApiSuccessSet = false;
            Api apiService = new ApiTestService();
            var clientService = new ClientTestService();
            ServiceHost clientHost = new ServiceHost(clientService, new Uri(PipeService));
            ServiceHost apiHost = new ServiceHost(apiService, new Uri(PipeService));
            //To let us know the services were successfully opened
            clientHost.Opened += (s, e) => ClientSuccessSet = true;
            apiHost.Opened += (s, e) => ApiSuccessSet = true;
            clientHost.AddServiceEndpoint(typeof(IClientService), new NetNamedPipeBinding(), ClientPipeServiceName);
            apiHost.AddServiceEndpoint(typeof(IApiService), new NetNamedPipeBinding(), ApiPipeServiceName);
            clientHost.BeginOpen(OnOpen, clientHost);
            apiHost.BeginOpen(OnOpen, apiHost);
            //This allows both services to be open for communication.
            while (!ApiSuccessSet || !ClientSuccessSet)
                Thread.Yield();
            EndpointAddress ApiEndpoint = new EndpointAddress(PipeService + @"/" + ApiPipeServiceName);
            EndpointAddress clientEndpoint = new EndpointAddress(PipeService + @"/" + ClientPipeServiceName);
            InstanceContext context = new InstanceContext((IClientCallback)new TestClientCallback());
            var ClientChannelFactory = new DuplexChannelFactory<IClientService>(context, new NetNamedPipeBinding(), clientEndpoint);
            var ApiChannelFactory = new ChannelFactory<IApiService>(new NetNamedPipeBinding(), ApiEndpoint);
            var ClientChannel = ClientChannelFactory.CreateChannel();
            var ApiChannel = ApiChannelFactory.CreateChannel();
            ClientChannelFactory.Close();
            ApiChannelFactory.Close();
            clientHost.Close();
            apiHost.Close();
        }
