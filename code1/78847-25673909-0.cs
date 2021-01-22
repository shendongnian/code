    namespace WCFServer
    {
        [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)] // required
        public class Program : IWCFService
        {
            private ServiceHost host;
            static void Main(string[] args)
            {
                new Program();
            }
            public Program()
            {
                host = new ServiceHost(this); // changed
                host.Open();
                Console.WriteLine("Server Started!");
                Console.ReadKey();
            }
            #region IWCFService Members
            public int CheckHealth(int id)
            {
                return (1);
            }
            #endregion
        }
    }
