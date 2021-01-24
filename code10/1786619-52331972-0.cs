    var generator = new Generator
    {
        OutputFolder = outputFolder,
        Log = s => Console.Out.WriteLine(s),
        GenerateNullables = true,
        NamespaceProvider = new Dictionary<NamespaceKey, string> 
            { 
                { new NamespaceKey("http://wadl.dev.java.net/2009/02"), "Wadl" } 
            }
            .ToNamespaceProvider(new GeneratorConfiguration { NamespacePrefix = "Wadl" }.NamespaceProvider.GenerateNamespace)
    };
    generator.Generate(files);
