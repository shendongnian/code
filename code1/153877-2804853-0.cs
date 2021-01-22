    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(MyService), new Uri[0]))
            {
                host.Open();
                Console.ReadKey();    
            }
        }
    }
