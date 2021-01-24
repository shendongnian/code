    public static class FunctionsAssemblyResolver
    {
        #region Public Methods
        public static void RedirectAssembly()
        {
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblyOnCurrentDomain;
        }
        #endregion Public Methods
        #region Private Methods
        private static Assembly ResolveAssemblyOnCurrentDomain(object sender, ResolveEventArgs args)
        {
            var requestedAssembly = new AssemblyName(args.Name);
            var assembly = default(Assembly);
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveAssemblyOnCurrentDomain;
            try
            {
                assembly = Assembly.Load(requestedAssembly.Name);
            }
            catch
            { }
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblyOnCurrentDomain;
            return assembly;
        }
        #endregion Private Methods
    }
