        AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = args.Name.Substring(0, args.Name.IndexOf(','));
            var assembly = ...load binary from embeded resources as you wish based on assemblyName...
            return Assembly.Load(assembly);
        }
