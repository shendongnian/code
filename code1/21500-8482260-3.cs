    public static IKernel CreateKernel()
    {
        var kernel = new StandardKernel();
        kernel.Scan(scanner => {
            scanner.FromAssembliesInPath(@"Path\To\Plugins");
            scanner.AutoLoadModules();
            scanner.WhereTypeInheritsFrom<IPlugin>();
            scanner.BindWith<PluginBindingGenerator<IPlugin>>();
        });
        return kernel;
    }
    private class PluginBindingGenerator<TPluginInterface> : IBindingGenerator
    {
        private readonly Type pluginInterfaceType = typeof (TPluginInterface);
        public void Process(Type type, Func<IContext, object> scopeCallback, IKernel kernel)
        {
            if(!pluginInterfaceType.IsAssignableFrom(type))
                return;
            if (type.IsAbstract || type.IsInterface)
                return;
            kernel.Bind(pluginInterfaceType).To(type);
        }
    }
