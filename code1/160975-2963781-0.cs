    class Foo
    {
        public Foo()
            : this(null)
        {
        }
        public Foo(string bar)
        {
            if (bar != null)
            {
                Console.WriteLine(bar);
            }
        }
    }
