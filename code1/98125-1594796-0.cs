    public interface IMyInterface
    {
        // note: I'm not sure this is the correct syntax, but I think I'm in the ballpark
        delegate IMyInterface MyInterfaceFactory ();
        string Foo ();
    }
    public abstract class MyGenericBaseClass<T> : IMyInterface
    {
        // ...
        abstract string Foo ();
    }
    public sealed class MyDerivedIntClass : MyGenericBaseClass<int>
    {
        // ...
        IMyInterface CreateObject () { return new MyDerivedIntClass (); }
    }
    
    public sealed class MyDerivedStringClass : MyGenericBaseClass<string>
    {
        // ...
        IMyInterface CreateObject () { return new MyDerivedStringClass (); }
    }
    
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
