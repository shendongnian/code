    IUnityContainer myContainer = new UnityContainer();
    myContainer.Configure<InjectedMembers>()
      .ConfigureInjectionFor<MyObject>( 
        new InjectionConstructor(12, "Hello Unity!"), 
        new InjectionProperty("MyStringProperty", "SomeText"));
