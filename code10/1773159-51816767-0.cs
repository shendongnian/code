    public static void RegisterTypes(IUnityContainer container) 
    { 
        container.RegisterType<IRegisterService, RegisterService>(); 
        container.RegisterType<IUnitOfWork, UnitOfWork>(); 
        DependencyResolver.SetResolver(new UnityDependencyResolver(container)); 
    }
