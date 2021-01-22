    public class Foo : IParameterlessConstructor
    {
        public Foo() // As per the interface
        {
        }
    }
    public class Bar : Foo
    {
        // Yikes! We now don't have a parameterless constructor...
        public Bar(int x)
        {
        }
    }
