    class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("http://localhost:13020");
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.None;
                using (ServiceHost sh=new ServiceHost(typeof(MyService),uri))
                {
                    sh.AddServiceEndpoint(typeof(IService), binding, "");
                    ServiceMetadataBehavior smb;
                    smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (smb==null)
                    {
                        smb = new ServiceMetadataBehavior()
                        {
                            HttpGetEnabled = true
                        };
                        sh.Description.Behaviors.Add(smb);
                    }
                    Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                    sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
                    sh.Opened += delegate
                    {
                        Console.WriteLine("service is ready...");
                    };
                    sh.Closed += delegate
                    {
                        Console.WriteLine("Service is closed now...");
                    };
                    sh.Open();
    
                    Console.ReadLine();
                    sh.Close();
                }
            }  
    }
