    interface IAStuff {
        TypeA AProp { get; }
        void DoSomethingToA();
    }
    
    interface IBStuff {
        TypeB BProp { get; }
        void DoSomethingToB();
    }
    
    public class Foo : IAStuff, IBStuff {
        TypeA AProp { get; private set; }
        TypeB BProp { get; private set; }
    
        void DoSomethingToA() { ... }
        void DoSomethingToB() { ... }
    }
