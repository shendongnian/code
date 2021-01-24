    class Context
    {
        private Dictionary<string, IStrategy> _strategyFactory = new Dictionary<string, IStrategy>();
        public Context(IStrategy[] strategies)
        {
            foreach (var s in strategies)
            {
                _strategyFactory.Add(s.Name, s);
            }
        }
        public void Run()
        {
            string userInput = "TypeA";
            IStrategy strategy = _strategyFactory[userInput];
            strategy.DoWork();
            userInput = "TypeB";
            strategy = _strategyFactory[userInput];
            strategy.DoWork();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mock DI Example: ");
            UnityContainer ioc = new UnityContainer();
            ioc.RegisterType<ITypeABusinessLogic, MockTypeABusinessLogic>();
            ioc.RegisterType<ITypeAApplicationLogic, MockTypeAApplicationLogic>();
            ioc.RegisterType<ITypeBBusinessLogic, MockTypeBBusinessLogic>();
            ioc.RegisterType<ITypeBApplicationLogic, MockTypeBApplicationLogic>();
            ioc.RegisterType<IStrategy, TypeAStrategy>("TypeA", new InjectionConstructor("TypeA", typeof(ITypeABusinessLogic), typeof(ITypeAApplicationLogic)));
            ioc.RegisterType<IStrategy, TypeBStrategy>("TypeB", new InjectionConstructor("TypeB", typeof(ITypeBBusinessLogic), typeof(ITypeBApplicationLogic)));
            Context c = ioc.Resolve<Context>();
            c.Run();
            Console.WriteLine("\nUnmocked DI Example: ");
            ioc = new UnityContainer();
            ioc.RegisterType<ITypeABusinessLogic, TypeABusinessLogic>();
            ioc.RegisterType<ITypeAApplicationLogic, TypeAApplicationLogic>();
            ioc.RegisterType<ITypeBBusinessLogic, TypeBBusinessLogic>();
            ioc.RegisterType<ITypeBApplicationLogic, TypeBApplicationLogic>();
            ioc.RegisterType<IStrategy, TypeAStrategy>("TypeA", new InjectionConstructor("TypeA", typeof(ITypeABusinessLogic), typeof(ITypeAApplicationLogic)));
            ioc.RegisterType<IStrategy, TypeBStrategy>("TypeB", new InjectionConstructor("TypeB", typeof(ITypeBBusinessLogic), typeof(ITypeBApplicationLogic)));
            c = ioc.Resolve<Context>();
            c.Run();
            Console.WriteLine("\nPress enter to exit...");
            Console.ReadLine();
        }
