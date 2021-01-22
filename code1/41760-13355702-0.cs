     class Program
    {
        static void Main(string[] args)
        {
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
            Evidence adevidence = AppDomain.CurrentDomain.Evidence;
            AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);
            Type type = typeof(Proxy);
            var value = (Proxy)domain.CreateInstanceAndUnwrap(
                type.Assembly.FullName,
                type.FullName);
            var assembly = value.GetAssembly(args[0]);
            // AppDomain.Unload(domain);
        }
    }
    public class Proxy : MarshalByRefObject
    {
        public Assembly GetAssembly(string assemblyPath)
        {
            try
            {
                return Assembly.LoadFile(assemblyPath);
            }
            catch (Exception)
            {
                return null;
                // throw new InvalidOperationException(ex);
            }
        }
    }
