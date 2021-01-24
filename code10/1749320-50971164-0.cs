    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IServiceC>()
                    .UsingFactoryMethod((kernel, context) => {
                        var request = (HttpRequestMessage)context.AdditionalArguments["request"];
                        var serviceC = new ServiceC(request);
                        return serviceC;
                    })
                    .LifestyleTransient()
            );
        }
    }
