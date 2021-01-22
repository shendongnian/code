    public class MyClient
    {
        private readonly IMyServiceFactory factory;
        public MyClient(IMyServiceFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            this.factory = factory;
        }
        // Use the WCF proxy
        public string Foo(string bar)
        {
            using(var proxy = this.factory.CreateChannel())
            {
                return proxy.Foo(bar);
            }
        }
    }
