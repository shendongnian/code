    Scan(assemblyScanner =>
                 {
                     assemblyScanner.TheCallingAssembly();
                     assemblyScanner.AddAllTypesOf(typeof (IRepository<>));
                     assemblyScanner.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
                 });
