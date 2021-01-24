    var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.GetTypes()
                .Any(t => t != typeof(Registry) && typeof(Registry).IsAssignableFrom(t))).ToList();
            registry.Scan(
                c =>
                {
                    assemblies.ForEach(a => c.Assembly(a));
                    c.LookForRegistries();
                });
