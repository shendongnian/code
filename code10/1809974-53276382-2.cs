    namespace Server8
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("http://localhost:1900");
                BasicHttpBinding binding = new BasicHttpBinding();
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
                    Binding binding1 = MetadataExchangeBindings.CreateMexHttpBinding();
                    sh.AddServiceEndpoint(typeof(IMetadataExchange), binding1, "mex");
                    sh.Open();
                    Console.WriteLine("Service is ready...");
    
                    Console.ReadLine();
                    sh.Close();
                }
    
            }
        }
        [ServiceContract(Namespace ="mydomain")]
        public interface IService
        {
            [OperationContract(Name ="AddInt")]
            int Add(int x, int y);
            
        }
        public class MyService : IService
        {
            public int Add(int x, int y)
            {
                return x + y;
            }
        }
    }
