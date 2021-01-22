    public sealed class AddinCustomConfigResolveHelper : IDisposable
    {
        public AddinCustomConfigResolveHelper(
            Assembly addinAssemblyContainingConfigSectionDefinition)
        {
            Contract.Assert(addinAssemblyContainingConfigSectionDefinition != null);
            this.AddinAssemblyContainingConfigSectionDefinition =
                addinAssemblyContainingConfigSectionDefinition;
            AppDomain.CurrentDomain.AssemblyResolve +=
                this.ConfigResolveEventHandler;
        }
        ~AddinCustomConfigResolveHelper()
        {
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool isDisposing)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= this.ConfigResolveEventHandler;
        }
        private Assembly AddinAssemblyContainingConfigSectionDefinition { get; set; }
        private Assembly ConfigResolveEventHandler(object sender, ResolveEventArgs args)
        {
            // often the name provided is partial...this will match full or partial naming
            if (this.AddinAssemblyContainingConfigSectionDefinition.FullName.Contains(args.Name))
            {
                return this.AddinAssemblyContainingConfigSectionDefinition;
            }
            return null;
        }
    }
