    class Program
    {
        static void Main(string[] args)
        {
            System.Type activator = typeof(RemoteProxy);
            AppDomain domain = 
                AppDomain.CreateDomain(
                    "friendly name", null,
                    new AppDomainSetup()
                    {
                        ApplicationName = "application name"
                    });
            ApplicationProxy proxy = 
                domain.CreateInstanceAndUnwrap(
                    Assembly.GetAssembly(activator).FullName,
                    activator.ToString()) as ApplicationProxy;
            proxy.DoSomething();
            AppDomain.Unload(domain);
        }
    }
