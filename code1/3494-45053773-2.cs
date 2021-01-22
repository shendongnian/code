    class C { }
    
    static void Foo(C x) => Console.WriteLine(nameof(Foo));
    static void Foo(object x) => Console.WriteLine(nameof(Object));
    
    public static void Main(string[] args)
    {
    	object x = new C();
    
    	Foo((dynamic)x); // prints: "Foo"
    	Foo(x);          // prints: "Object"
    }
