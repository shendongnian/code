    internal class DryIocServiceProviderFactory : IServiceProviderFactory<IContainer>
    {
        public IContainer CreateBuilder(IServiceCollection services)
            => new Container().WithDependencyInjectionAdapter(services);
        public IServiceProvider CreateServiceProvider(IContainer containerBuilder)
            => containerBuilder.ConfigureServiceProvider<CompositionRoot>();
    }
