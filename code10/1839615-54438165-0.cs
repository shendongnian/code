    public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
        RegisterAssemblyInterfaces(this ContainerBuilder builder, Assembly assembly, object lifetimeScope)
    {
        return builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .InstancePerMatchingLifetimeScope(lifetimeScope);
    }
