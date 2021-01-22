    public delegate void Foo1();
    public delegate void Foo2(int val);
    
    public void Foo()
    {
        Foo1 first = delegate { Console.WriteLine("Hello world"); };
        Foo2 second = delegate { Console.WriteLine("Hello world"); };
        Foo1 third = delegate() { Console.WriteLine("Hello world"); };
        Foo2 fourth = delegate() { Console.WriteLine("Hello world"); }; // does not compile
    }
