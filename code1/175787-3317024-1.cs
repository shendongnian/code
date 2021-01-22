    class Program
    {
        [ImportMany] // [Import]
        public IEnumerable<string> Messages { get; set; }
        [ImportMany] // [Import]
        public IEnumerable<IOutputString> OutputSet { get; set; }
        [Import("OutputMessages")]
        public Action<IEnumerable<IOutputString>, IEnumerable<string>> OutputMessages { get; set; }
        public void Run()
        {
            var catalog = new AggregateCatalog(); // AggregatingComposablePartCatalog
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\ExternalMessages\bin\Debug")); // DirectoryPartCatalog
            catalog.Catalogs.Add(new DirectoryCatalog(@"..\..\..\ExtraMessages")); // DirectoryPartCatalog
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly())); // AttributedAssemblyPartCatalog
            var container = new CompositionContainer(catalog); // CompositionContainer(catalog.CreateResolver());
            
            // container.AddPart(this);
            // container.Compose();
            container.ComposeParts(this);
            OutputMessages(OutputSet, Messages);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
    }
