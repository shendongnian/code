    public class StructureMapContainerFactory : IServiceProviderFactory<IContainer>
    {
        private readonly IWorkingPath workingPath;
        // pass any dependencies to your factory
        public StructureMapContainerFactory(IWorkingPath workingPath)
        {
            this.workingPath = workingPath;
        }
        public IContainer CreateBuilder(IServiceCollection services)
        {
            services.AddStructureMap();
            return ContainerBuilder.BuildBaseContainer(services, workingPath);
        }
        public IServiceProvider CreateServiceProvider(IContainer containerBuilder)
        {
            return containerBuilder.GetInstance<IServiceProvider>();
        }
    }
