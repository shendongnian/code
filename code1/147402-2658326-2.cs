        private void App_Startup(object sender, StartupEventArgs e)
        {
            // Since we'll be dynamically loading assemblies at runtime, 
            // we need to add an appropriate resolution path
            // Otherwise weird things like failing to instantiate TypeConverters will happen
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var domain = (AppDomain) sender;
            foreach (var assembly in domain.GetAssemblies())
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }
            return null;
        }
 
