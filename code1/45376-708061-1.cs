    static void MethodA(int a, int b)
    {
        using (var foo = new MySingleton<Foo>(() => new Foo()))
        {
            if (a > 3)
            {
                Use(foo);
    
                if (a * b == 35)
                {
                    GC.Collect(); // Simulate GC
                    Use(foo);
                }
                else if (b % 6 == 2)
                {
                    Use(foo);
                }
            }
        }
    }
