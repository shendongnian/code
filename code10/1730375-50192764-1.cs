    [Serializable]
    class PluginLoader
    {
        private readonly byte[] _myBytes;
        private readonly AppDomain _newDomain;
        public PluginLoader(byte[] rawAssembly)
        {
            _myBytes = rawAssembly;
            _newDomain = AppDomain.CreateDomain("New Domain");
            _newDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
        }
        public void Test()
        {
            _newDomain.CreateInstance("plugin", "Plugins.Test");
        }
        private Assembly MyResolver(object sender, ResolveEventArgs args)
        {
            AppDomain domain = (AppDomain)sender;
            Assembly asm = domain.Load(_myBytes);
            return asm;
        }
    }
