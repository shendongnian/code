        public class DependencyInjectionContainer : IContainer
        {
            protected IKernel Kernel { get; set; }
            public DependencyInjectionContainer(IKernel kernel)
            {
                Kernel = kernel;
            }
            public T Resolve<T>()
            {
                return Kernel.Resolve<T>();
            }
        }
        public class DependencyInjectionInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(
                    Component
                        .For<IContainer>()
                        .ImplementedBy<DependencyInjectionContainer>()
                );
            }
        }
