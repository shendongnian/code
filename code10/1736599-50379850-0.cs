        var assemblies = executingAssembly.GetReferencedAssemblies();
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray()();
        foreach (var assemblyName in assemblies)
        {
            var assembly = loadedAssemblies.FirstOrDefault(a => a.FullName == assemblyName.FullName) ??
                           AppDomain.CurrentDomain.Load(assemblyName);
            Type controller = assembly.GetTypes()
                .FirstOrDefault(type => type.Name.ToLower() == string.Format("{0}Controller",this.RouteData["controller"].ToString()).ToLower());
        }
