    // SpellingChecker is subclass of Type3
    IUnityContainer container = new UnityContainer();
    container.RegisterType<Type3>(typeof(SpellingChecker));
    
    // DocumentViewer is subclass of Type2
    Type1Factory factory = container.Resolve<Type1Factory>();
    Type1 type1 = factory.GetType1(new DocumentViewer());
