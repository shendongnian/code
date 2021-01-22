    // ... somewhere else in the code ...
    // create a IMyInterface object using a factory method and do something with it
    void Bar (MyInterfaceFactory factory)
    {
        IMyInterface mySomething = factory ();
        string foo = mySomething.Foo ();
    }
    // ... somewhere else in the code ...
    void FooBarAnInt ()
    {
        Bar (MyDerivedIntClass.CreateObject);
    }
