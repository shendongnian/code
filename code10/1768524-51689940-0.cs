    CompositionContainer _container = null;
    .
    .
    .
    AggregateCatalog catalog = new AggregateCatalog();
    .
    .
    .
    String fileName = "pug-in1.dll"
    .
    .
    .
    Byte[] contFile = File.ReadAllBytes(fileName);
    Assembly ass = Assembly.Load(contFile);
    AssemblyCatalog assCat = new AssemblyCatalog(ass);
    
    catalog.Catalogs.Add(assCat);
    
    _container = new CompositionContainer(catalog)
    
    try
    {
        _container.ComposeParts(this);
    }
    catch (CompositionException compositionException)
    {
        Console.WriteLine(compositionException.ToString());
    }
    .
    .
    .
