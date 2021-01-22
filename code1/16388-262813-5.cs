    namespace Ns1.Foo.Bar
    {
        using Ns1.Foo.Foo2;
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
