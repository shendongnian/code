            var path = "C:\\rust server\\RustDedicated_Data\\Managed";
            var coreFiles = Directory.GetFiles(path, "vmecore.*.dll");
            var coreExtension = new List<Type>();
            // Load each assembly into domain
            foreach (var file in coreFiles)
            {
                var lAssembly = Assembly.LoadFile(file);
                var assembly = Assembly.Load(lAssembly.FullName);
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => t.IsAssignableTo<IVmeExtension>())
                    .SingleInstance();
                // Add all IVmeExtension types
                coreExtension.AddRange(assembly.GetExportedTypes()
                    .Where(a => a.IsClass &&
                                !a.IsAbstract &&
                                a.Namespace != null &&
                                a.Namespace.Contains(@"VME") &&
                                typeof(IVmeExtension).IsAssignableFrom(a)));
            }
