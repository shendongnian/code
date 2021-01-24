       Uri uri = new Uri("http://localhost:11011");
        WSHttpBinding binding = new WSHttpBinding();
        binding.Security.Mode = SecurityMode.None;
        using (ServiceHost sh=new ServiceHost(typeof(MyService),uri))
        {
            sh.AddServiceEndpoint(typeof(IService), binding, "");
            ServiceMetadataBehavior smb;
            smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb==null)
            {
                smb = new ServiceMetadataBehavior()
                {
                };
                sh.Description.Behaviors.Add(smb);
            }
            Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
            sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
            sh.Opened += delegate
            {
                Console.WriteLine("Service is ready");
            };
            sh.Closed += delegate
            {
                Console.WriteLine("Service is clsoed");
            };                
            sh.Open();
