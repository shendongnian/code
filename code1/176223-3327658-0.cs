    void Foo<TFactory, T>() where TFactory : IFactory<T> 
                            where TFactory : new() {
       var factory = new TFactory();
       T val = factory.Create(xmlNode); // Create method is defined in IFactory<T>
       // ...
    }
