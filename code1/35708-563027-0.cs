    class Foo<T> : IFoo
    {
    
        public Foo(string name)
        {
            Name = name;
        }
        string Name { get; set; }
        T Value {get; set;}
        Type FooType { get { return typeof(T); } }
    }
