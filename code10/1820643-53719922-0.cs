    class Program
        {
    
            static void Main(string[] args)
            {
                Uri uri = new Uri("http://localhost:1500");
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.TransferMode = TransferMode.Buffered;
                binding.Security.Mode = BasicHttpSecurityMode.None;
                ServiceHost sh = new ServiceHost(typeof(Calculator),uri);
                sh.AddServiceEndpoint(typeof(ICalculator), binding, "");
                ServiceMetadataBehavior smb;
                smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                    //smb.HttpGetEnabled = true;
                    sh.Description.Behaviors.Add(smb);
                }
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "MEX");
    
    
                sh.Open();
                Console.Write("Service is ready....");
                Console.ReadLine();
                sh.Close();
            }
        }
        [ServiceContract]
        public interface ICalculator
        {
            [OperationContract,WebGet]
            double Add(double a, double b);
    
        }
    
        public class Calculator : ICalculator
        {
            public double Add(double a, double b)
            {
                return a + b;
            }
    
    }
