     public IViewFor ResolveView<T>(T viewModel, string contract = null)
                where T : class
            {
                var typeToFind = ViewModelToViewFunc(viewModel.GetType().AssemblyQualifiedName);
    
                var ret = attemptToResolveView(Reflection.ReallyFindType(typeToFind, false), contract);
                if (ret != null) return ret;
    
                // IViewFor<FooBarViewModel> (the original behavior in RxUI 3.1)
                var viewType = typeof(IViewFor<>);
                ret = attemptToResolveView(viewType.MakeGenericType(viewModel.GetType()), contract);
                if (ret != null) return ret;
    
    
                // check ViewModel's assembly
                var typeAssembly = viewModel.GetType().Assembly;
                var types = typeAssembly.GetExportedTypes()
                    .SelectMany(x => x.GetInterfaces()
                    .Where(i => i.Name.Contains("IViewFor")))
                    .ToArray(); // all IViewFor from assembly
    
                types = types.Where(x => x.FullName.Contains(viewModel.GetType().Name.Replace("ViewModel", "View"))).ToArray(); // only IViewFor<ViewModel>
    
                foreach (var type in types) // in case there is more than one registration - contracts
                {
                    ret = attemptToResolveView(type, contract);
                    if (ret != null) return ret;
                }
    
                return null;
            }
