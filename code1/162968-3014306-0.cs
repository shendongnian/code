    static void Main(string[] args)
    {   
        var exeCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
        var dircatalog = new DirectoryCatalog(".");
        var aggregateCatalog = new AggregateCatalog(exeCatalog, dirCatalog);
        var container = new CompositionContainer(aggregateCatalog);
        var program = container.GetExportedValue<Program>();
    
        program.Run();
    }
