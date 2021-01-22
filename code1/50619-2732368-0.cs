    _unityContainer.RegisterType<IDataContext,DataContextA>("DataContextA", new ContainerControlledLifeTimeManager());
    _unityContainer.RegisterType<IDataContext,DataContextB>("DataContextB");
    
      var repositoryA = _unityContainer.Resolve<IRepositoryA>(new InjectionConstructor(
    new ResolvedParameter<IDataContext>("DataContextA")));
       
      var repositoryB = _unityContainer.Resolve<IRepositoryB>(new InjectionConstructor(
    new ResolvedParameter<IDataContext>("DataContextA")));
    
      var repositoryA2 = _unityContainer.Resolve<IRepositoryA>(new InjectionConstructor(
    new ResolvedParameter<IDataContext>("DataContextB")));
