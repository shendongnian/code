    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost hostA = new ServiceHost(typeof(ServiceAImplementation), new Uri("http://127.0.0.1:6600/"));
                ServiceHost hostB = new ServiceHost(typeof(ServiceBImplementation), new Uri("http://127.0.0.1:6601/"));
    
                InitHost<ServiceAInterface>(hostA, "ServiceA.soap");
                InitHost<ServiceBInterface>(hostB, "ServiceB.soap");
    
                try
                {
                    hostA.Open();
                    hostB.Open();
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine("Timeout");
                }
                catch (CommunicationException ex)
                {
                    Console.WriteLine("Communication problem");
                }
                finally
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();
                    hostA.Close();
                    hostB.Close();
                }
            }
    
            private static BasicHttpBinding GetBinding()
            {
                var binding = new BasicHttpBinding();
                binding.MaxBufferSize = int.MaxValue;
                binding.MaxReceivedMessageSize = int.MaxValue;
                binding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                binding.AllowCookies = true;
                binding.MaxReceivedMessageSize = int.MaxValue;
    
                return binding;
            }
    
            private static void InitHost<T>(ServiceHost host, string endpointEnd)
            {
                host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                host.Description.Behaviors.Add(
                    new ServiceDebugBehavior
                    {
                        IncludeExceptionDetailInFaults = true
                    });
                host.AddServiceEndpoint(typeof(T), GetBinding(), endpointEnd);
    
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                    smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                host.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );
            }
        }
    }
