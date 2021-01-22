    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
    {
        var resName = args.Name + ".dll";    
        var thisAssembly = Assembly.GetExecutingAssembly();    
        using (var input = thisAssembly.GetManifestResourceStream(resName))
        {
            return input != null 
                 ? Assembly.Load(StreamToBytes(input))
                 : null;
        }
    };
