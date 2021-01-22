    foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies()) {
        Assembly assembly = Assembly.Load(assemblyName);
        foreach (var type in assembly.GetTypes()) {
            Console.WriteLine(type.Name);
        }
    }
