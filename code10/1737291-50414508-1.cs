    IGenericFactory<Foo, FooEnum> inter = GetTheInterface();
    FooFactory fn = inter; // implicit conversion to wrapper type
    
    DoWork(fn); // use the "friendly name" like it were it's wrapped type
                // implicit conversion back to wrapped type
    
    public void DoWork(IGenericFactory<Foo, FooEnum> fooFactory) {
        ...
    }
