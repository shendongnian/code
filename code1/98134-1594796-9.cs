    public interface IMyInterfaceFactory
    {
        IMyInterface CreateObject ();
    }
    public class MyDerivedIntFactory : IMyInterfaceFactory
    {
        public IMyInterface CreateObject () { return new MyDerivedIntClass (); }
    }
    public class MyDerivedStringFactory : IMyInterfaceFactory
    {
        public IMyInterface CreateObject () { return new MyDerivedStringClass (); }
    }
    // ... somewhere else ...
    // create a IMyInterface object using a factory class and do something with it
    void Bar (IMyInterfaceFactory factory)
    {
        IMyInterface mySomething = factory.CreateObject ();
        string foo = mySomething.Foo ();
    }
    // ... somewhere else in the code ...
    void FooBarAnInt ()
    {
        Bar (new MyDerivedIntFactory ());
    }
