    public class MyClass
    {
        // default constructor. personally, I would opt to use a container
        // like Castle Windsor Container, or Microsoft's Unity, but if you
        // have no control over application or it's just this "one" thing,
        // just default to a concrete implementation below.
        public MyClass () : this (new RuntimeInfo ()) { }
        // what we call an "injector" constructor, because runtime info is
        // passed - or "injected" - into instance.
        public MyClass (IRuntimeInfo runtimeInfo) { ... }
        ...
    }
