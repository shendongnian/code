    // Util.cs
    static class Util 
    {
        static void DoSomething( FooBase foo ) {}
    }
    // FooBase.cs
    class FooBase
    {
        virtual void Do() { Util.DoSomething( this ); }
    }
    // FooDerived.cs
    class FooDerived : FooBase
    {
        override void Do() { ... }
    }
    // FooDerived2.cs
    class FooDerived2 : FooDerived
    {
        override void Do() { Util.DoSomething( this ); }
    }
