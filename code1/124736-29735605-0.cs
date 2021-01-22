    using System;
    using System.Collections.Generic;
    class MainApp
    {
        static void Main()
        {
            LoadBalancer oldbalancer = null;
            for (int i = 0; i < 15; i++)
            {
                LoadBalancer balancerNew = LoadBalancer.GetLoadBalancer();
    
                if (oldbalancer == balancerNew && oldbalancer != null)
                {
                    Console.WriteLine("{0} SameInstance {1}", oldbalancer.Server, balancerNew.Server);
                }
                oldbalancer = balancerNew;
            }
            Console.ReadKey();
        }
    }
    
    class LoadBalancer
    {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();
    
        private static object syncLock = new object();
    
        private LoadBalancer()
        {
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }
    
        public static LoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }
    
            return _instance;
        }
    
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }
