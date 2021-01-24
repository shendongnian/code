    public class Startup
    {
        
        public Startup( IHostingEnvironment hostingEnvironment)
        {
           
            _hostingEnvironment = hostingEnvironment;
        }
        private readonly IHostingEnvironment _hostingEnvironment;
      
      
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddMvc()
                          .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                          .ConfigureApplicationPartManager(ConfigureApplicationParts); ;
        }
      
        
        private void ConfigureApplicationParts(ApplicationPartManager apm)
        {
            string rootPath = _hostingEnvironment.ContentRootPath;
            var pluginsPath = Path.Combine(rootPath, "Plugins");
            var assemblyFiles = Directory.GetFiles(pluginsPath, "Plugin*.dll", SearchOption.AllDirectories);
            foreach (var assemblyFile in assemblyFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(assemblyFile);
                    if (assemblyFile.EndsWith(".Views.dll"))
                        apm.ApplicationParts.Add(new 
                               CompiledRazorAssemblyPart(assembly));
                    else
                        apm.ApplicationParts.Add(new AssemblyPart(assembly));
                }
                catch (Exception e) { }
            }
        }
    }
