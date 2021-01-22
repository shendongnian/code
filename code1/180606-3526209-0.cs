    public class Global : HttpApplication, IContainerProviderAccessor
    {
       private static IContainerProvider _containerProvider;
    
       protected void Application_Start(object sender, EventArgs e)
       {
          var container = new UnityContainer();
          container.AddNewExtension<MyWebModule>();
    
          _containerProvider = new ContainerProvider(container);
       }
    
    [...]
    
       public IContainerProvider ContainerProvider
       {
          get { return _containerProvider; }
       }
    }
    
    public class MyWebModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<ApplicationModule>();
            Container.AddNewExtension<DomainModule>();
        }
    }
    
    public class ApplicationModule: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ProductPrensenter>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new ProductPresenter(c.Resolve<IProductView>())));
        }
    }
