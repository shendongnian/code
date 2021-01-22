    AContainerClass aContainer = new AContainerClass();
    SomeDisposableObject originalInstance = aContainer.SomeObject;
    aContainer.SomeObject = new SomeDisposableObject();
    aContainer.DoSomething();
    aContainer.SomeObject = originalInstance;
