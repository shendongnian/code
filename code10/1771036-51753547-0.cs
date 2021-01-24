    public class FormsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("MyViews")
                .BasedOn<IView>()
                .WithServiceAllInterfaces()
                .LifestyleSingleton());
        }
    }
