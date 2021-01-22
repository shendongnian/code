    static void Main(string[] args)
    {
        MethodA(5, 7);
        MethodA(8, 9);
    }
    
    static void MethodA(int a, int b)
    {
        var foo = WeakCacheFor<Foo>(() => new Foo());
        
        if (a > 3)
        {
            Use(foo);
            
            if (a * b == 35)
            {
                GC.Collect(); // Simulate GC
                Use(foo);
            }
            else if(b % 6 == 2)
            {
                Use(foo);
            }
        }
    }
