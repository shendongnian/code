        /// <summary>
        /// Get the types defined in the RootComponent.
        /// </summary>
        private List<Type> getAssemblyTypes(IServiceProvider provider) {
            var types = new List<Type>();
            try {
                IDesignerHost host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
                ITypeResolutionService resolution = (ITypeResolutionService)provider.GetService(typeof(ITypeResolutionService));
                AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
                    foreach (var assembly in ((AppDomain)sender).GetAssemblies()) {
                        if (assembly.FullName == args.Name) {
                            MessageBox.Show(args.Name);
                            return assembly;
                        }
                    }
                    return null;
                };
                Type rootComponentType = resolution.GetType(host.RootComponentClassName, false);
                types = rootComponentType.Assembly.GetTypes().ToList();
            } catch { }
            return types;
        }
