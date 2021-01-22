    class Program
    {
        static CompositionContainer CreateContainer()
        {
            var logFactoryProvider = new ServiceExportProvider<ILog>(LogManager.GetLogger);
            var catalog = new AssemblyCatalog(typeof(Program).Assembly);
            return new CompositionContainer(catalog, logFactoryProvider);
        }
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            var container = CreateContainer();
            var part = container.GetExport<Part>().Value;
            part.Log.Info("Hello, world! - 1");
            var anotherPart = container.GetExport<AnotherPart>().Value;
            anotherPart.Log.Fatal("Hello, world! - 2");
        }
    }
