    private void RegisterGenericMasterDataCommandHandlers(IWindsorContainer container) {
        foreach (Type contractType in contractTypes) {
            Type requestedType = typeof(IRequestHandler<,>).MakeGenericType(typeof(AddMasterDataEntityCommand<>).MakeGenericType(contractType), typeof(Response));
            Type implementedType = typeof(AddMasterDataEntityCommandHandler<>).MakeGenericType(contractType);
            container.Register(Component.For(requestedType, implementedType));
        }
    }
