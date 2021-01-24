    public class MyClass : IIntf
    {
        public string Foo { get; private set; }
        string IIntf.Foo { get => Foo; set => Foo = value; }
    }
