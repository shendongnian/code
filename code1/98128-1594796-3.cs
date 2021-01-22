    public sealed class MyDerivedIntClass : MyGenericBaseClass<int>
    {
        // ...
        static IMyInterface CreateObject () { return new MyDerivedIntClass (); }
    }
    
    public sealed class MyDerivedStringClass : MyGenericBaseClass<string>
    {
        // ...
        static IMyInterface CreateObject () { return new MyDerivedStringClass (); }
    }
