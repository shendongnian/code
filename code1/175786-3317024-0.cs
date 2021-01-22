    class Program
    {
        [ImportMany]
        public IEnumerable<string> Messages { get; set; }
        [ImportMany]
        public IEnumerable<IOutputString> OutputSet { get; set; }
        [Import("OutputMessages")]
        public Action<IEnumerable<IOutputString>, IEnumerable<string>> OutputMessages { get; set; }
        public void Run()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\ExternalMessages\bin\Debug"));
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\ExtraMessages"));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
            OutputMessages(OutputSet, Messages);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
    }
