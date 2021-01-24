        public class IgniteInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(
                    Component
                        .For<IIgnite>()
                        .UsingFactoryMethod(() => Ignition.Start(new IgniteConfiguration
                        {
                            PluginConfigurations = new[] {new DependencyInjectionPluginConfiguration()}
                        }))
                );
            }
        }
