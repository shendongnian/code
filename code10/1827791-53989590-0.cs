    ServiceHost svcHost = new ServiceHost(typeof(UsageLogger), new Uri("http://localhost:15616/UsageLogger"));
                try
                {
                    ServiceMetadataBehavior smb = svcHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    
                    if (smb == null)
                        smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    svcHost.Description.Behaviors.Add(smb);                
                    svcHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");                
                    svcHost.AddServiceEndpoint(typeof(IUsageLogger), new BasicHttpBinding(), "");                
                    svcHost.Open();               
                    Console.WriteLine("The service is ready.");                
                    Console.ReadLine();                
                    svcHost.Close();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine("There was a communication problem. " + commProblem.Message);
                    Console.Read();
                }
