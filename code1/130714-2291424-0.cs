    var t = Assembly
       .GetExecutingAssembly()
       .GetReferencedAssemblies()
       .Select(x => Assembly.Load(x))
       .SelectMany(x => x.GetTypes()).First(x => x.FullName == typeName);
