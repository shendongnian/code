    IDataContext context = _unityContainer.Resolve<IDataContext>();
    _unityContainer.RegisterInstance(context);
    var repositoryA = _unityContainer.Resolve<IRepositoryA>(); //Same instance of context
    var repositoryB = _unityContainer.Resolve<IRepositoryB>(); //Same instance of context
    //declare _unityContainer2
    IDataContext context2 = _unityContainer2.Resolve<IDataContext>(); //New instance
    _unityContainer2.RegisterInstance(context2);
    var repositoryA2 = _unityContainer2.Resolve<IRepositoryA>(context2); //will retrieve the other instance
