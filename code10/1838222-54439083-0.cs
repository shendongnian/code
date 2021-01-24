    container.RegisterType<DocumentPreparation , DocumentPreparation>(
        new HierarchicalLifetimeManager(),
        new InjectionFactory(c => new DocumentPreparation(
            c.ResolveAll<IFunctionary<IOrder>>()
                .Where(f => {
                    var typeNamespace = f.GetType().Namespace;
                    return typeNamespace != null && typeNamespace == "Preparation";
                }).ToArray(),
            c.ResolveAll<IFunctionary<IBill>>()
                .Where(f => {
                    var typeNamespace = f.GetType().Namespace;
                    return typeNamespace != null && typeNamespace == "Preparation";
                }).ToArray())
            ));
