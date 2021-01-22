    public class Foo
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
    ...
    var foo = new Foo { A = 1, B = 2, C = 3 };
    FooWrapper.DoSomethingWithFoo(foo);
