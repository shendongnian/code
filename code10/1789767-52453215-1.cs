    public static class DependencyConfiguration
    
    {
        public static UnityContainer Config()
        {
            var unity = new UnityContainer();
            unity.RegisterType<IHandler, Handler1>("Handler1");
            unity.RegisterType<IHandler, Handler2>("Handler2");
            unity.RegisterType<IEnumerable<IHandler>>();
            
    
            return unity;
        }
    }
