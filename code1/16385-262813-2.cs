    using Ns1.Foo.Foo2;
    
    namespace Ns1.Foo
    {
        class Foo
        {
            public void Print()
            {
                System.Console.WriteLine("Ns1.Foo");
            }
        }
    }
    
    namespace Ns1.Foo.Foo2
    {
        class Foo
        {
            public void Print()
            {
                System.Console.WriteLine("Ns1.Foo.Foo2");
            }
        }
    }
    
    namespace Ns1.Foo.Bar
    {
        class Bar
        {
            public void Print()
            {
                new Foo().Print();
            }
    
            static void Main()
            {
                new Bar().Print();
            }
        }
    }
