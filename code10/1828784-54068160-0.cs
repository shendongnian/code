    class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost sh=new ServiceHost(typeof(MyService)))
                {
                    sh.Opened += delegate
                    {
                        Console.WriteLine("Service is ready......");
                    };
                    sh.Closed += delegate
                    {
                        Console.WriteLine("Service is closed");
                    };
                    sh.Open();
                    Console.ReadLine();
                    sh.Close();
    
                }
            }
        }
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            [WebGet]
            string SayHello();
        }
        public class MyService : IService
        {
            public string SayHello()
            {
    return "Hello, Busy world";        }
    }
