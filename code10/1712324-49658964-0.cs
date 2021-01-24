        /// <summary>
        /// Loads modules from specified assemblies that don't already exist in the kernel.
        /// </summary>
        public static void LoadIfNotLoaded(this IKernel kernel, IEnumerable<Assembly> assemblies)
        {
            var existingModules = kernel.GetModules();
            var newModules = assemblies.SelectMany(a => a.GetNinjectModules())
                .Where(m => !existingModules.Any(em => em.GetType() == m.GetType()));
            kernel.Load(newModules);
        }
