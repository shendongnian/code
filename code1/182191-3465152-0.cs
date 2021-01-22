    // Two delegate types with the same signature
    delegate void Foo();
    delegate void Bar();
    
    class Test
    {
        static void Main()
        {
            // Actual value is irrelevant here
            Foo foo = null;
            // Error: can't convert like this
            // Bar bar = foo;
            // This works fine
            Bar bar = new Bar(foo);
        }
    }
