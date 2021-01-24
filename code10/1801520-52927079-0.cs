    class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost sh=new ServiceHost(typeof(MyService)))
                {
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
                    sh.Open();
                    Console.WriteLine("Service is ready");
    
                    Console.ReadKey();
                    sh.Close();
                }
            }
        }
        [ServiceContract(Namespace ="mydomain",Name = "demo", ConfigurationName = "isv", CallbackContract = typeof(ICallback))]
        public interface IDemo
        {
            [OperationContract(Action = "post_num", IsOneWay = true)]
            void PostNumber(int n);
        }
        [ServiceContract]
        public interface ICallback
        {
            [OperationContract(Action = "report", IsOneWay = true)]
            void Report(double progress);
        }
    
        [ServiceBehavior(ConfigurationName ="sv")]
        public class MyService : IDemo
        {
            public void PostNumber(int n)
            {
                ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
                for (int i = 0; i <=n; i++)
                {
                    Task.Delay(500).Wait();
                    double p = Convert.ToDouble(i) / Convert.ToDouble(n);
                    callback.Report(p);
                }
            }
        }
