    public class AutoMapperConfigurationRegistry : Registry
        {
            public AutoMapperConfigurationRegistry()
            {
                ForRequestedType<Configuration>()
                    .CacheBy(InstanceScope.Singleton)
                    .TheDefault.Is.OfConcreteType<Configuration>()
                    .CtorDependency<IEnumerable<IObjectMapper>>().Is(expr => expr.ConstructedBy(MapperRegistry.AllMappers));
    
                ForRequestedType<ITypeMapFactory>().TheDefaultIsConcreteType<TypeMapFactory>();
    
                ForRequestedType<IConfigurationProvider>()
                    .TheDefault.Is.ConstructedBy(ctx => ctx.GetInstance<Configuration>());
    
                ForRequestedType<IConfiguration>()
                    .TheDefault.Is.ConstructedBy(ctx => ctx.GetInstance<Configuration>());
            }
        }
