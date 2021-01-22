        var listOfBs = (
                        from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                        // alternative: from domainAssembly in domainAssembly.GetExportedTypes()
                        from assemblyType in domainAssembly.GetTypes()
                        where typeof(B).IsAssignableFrom(assemblyType)
                        // alternative: where assemblyType.IsSubclassOf(typeof(B))
                        // alternative: && ! assemblyType.IsAbstract
                        select assemblyType).ToArray();
