    ClassA a = new ClassA();
    using (ClassB b = new ClassB()) // implements IDisposable
    {
        b.SubscribeToFoo(a); // b subscribes to FooEvent of ClassA
        a.DoFoo(); // a executes FooEvent
    }
    GC.Collect(); // Run Garbage Collector just to be sure
    a.DoFoo(); // a executes FooEvent
