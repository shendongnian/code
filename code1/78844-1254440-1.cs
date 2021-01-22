    namespace WCFServer
    {
        public class Program
        {
            private ServiceHost host;
    
            static void Main(string[] args)
            {
                new Program();
            }
    
            public Program()
            {
                host = new ServiceHost(typeof(WCF));
    
                host.Open();
    
                Console.WriteLine("Server Started!");
    
                Console.ReadKey();
            }
        }
    
        public class WCF : IWCFService
        {
    
            #region IWCFService Members
    
            public int CheckHealth(int id)
            {
                return (1);
            }
    
            #endregion
        }
    }
