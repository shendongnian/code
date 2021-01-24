    public class Startup
    {
        // ...
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyLoader = new DotNetCoreAssemblyLoader(searchPattern: "FeatureLib*.dll");
            services.AddMvc()
                .ConfigureApplicationPartManager(_ =>
                {
                    foreach (var assembly in assemblyLoader.Assemblies)
                    {
                        if (assembly.FullName.Contains("Views"))
                        {
                            _.ApplicationParts.Add(new CompiledRazorAssemblyPart(assembly));
                        }
                        else
                        {
                            _.ApplicationParts.Add(new AssemblyPart(assembly));
                        }
                    }
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        // ...
    }
