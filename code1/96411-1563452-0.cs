            Scan(scanner =>
            {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                scanner.AssembliesFromPath(assemblyPath, assembly => { return assembly.GetName().Name.StartsWith("Plugin."); });
                scanner.With(typeScanner);
            });
