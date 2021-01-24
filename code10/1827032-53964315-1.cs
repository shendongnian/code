    public class WindsorConfiguration : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<ICustomService, CustomServiceOne>().Named("TypeOne"),
                Component.For<ICustomService, CustomServiceTwo>().Named("TypeTwo"),
                Component.For<ICustomService, CustomServiceThree>().Named("TypeThree"),
                Component.For<ICustomService, CustomServiceOne>().IsDefault(),
                Component.For<ICustomServiceFactory>().AsFactory(new CustomServiceSelector())
            );
        }
    }
    public class CustomServiceSelector : DefaultTypedFactoryComponentSelector
    {
        public CustomServiceSelector()
            : base(fallbackToResolveByTypeIfNameNotFound: true) { }
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
           return (string) arguments[0];
        }
    }
