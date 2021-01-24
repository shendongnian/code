    builder.RegisterGeneric(typeof(Foo<>))
            .As(typeof(IFoo<>))
            .OnActivated(e =>
            {
                Boolean isValid = e.Component.Services
                    .OfType<IServiceWithType>()
                    .Where(s => s.ServiceType.IsConstructedGenericType
                                && s.ServiceType.GetGenericTypeDefinition() == typeof(IFoo<>)
                                && s.ServiceType.GetGenericArguments()[0].IsAssignableTo<IBar>())
                    .Any();
                if (!isValid)
                {
                    throw new Exception("boom");
                }
            });
