    namespace SeperateAppDomainTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                LoadAssembly();
            }
    
            public static void LoadAssembly()
            {
                string pathToDll = Assembly.GetExecutingAssembly().CodeBase;
                AppDomainSetup domainSetup = new AppDomainSetup { PrivateBinPath = pathToDll };
                var newDomain = AppDomain.CreateDomain("FooBar", null, domainSetup);
                ProxyClass c = (ProxyClass)(newDomain.CreateInstanceFromAndUnwrap(pathToDll, typeof(ProxyClass).FullName));
                Console.WriteLine(c == null);
    
                Console.ReadKey(true);
            }
        }
    
        public class ProxyClass : MarshalByRefObject { }
