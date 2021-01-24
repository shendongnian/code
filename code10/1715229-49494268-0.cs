    private static Type GetType(string typeName)
    {
        // check executing assembly
        var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.FullName == typeName);
        // if not found check referenced assemblies
        if (type == null)
        {
            type = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => x.FullName == typeName);
        }
        // if still not found check all suitably named assemblies in executing folder
        if (type == null)
        {
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            if (files.Length == 0)
            {
                files = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll");
            }
            files.ToList().ForEach(filename =>
            {
                if (type == null)
                {
                    var assembly = Assembly.LoadFile(filename);
                    var castableAssembly = AppDomain.CurrentDomain.Load(assembly.GetName());
                    type = castableAssembly.GetTypes().FirstOrDefault(x => x.FullName == typeName);
                }
            });
        }
        return type;
    }
