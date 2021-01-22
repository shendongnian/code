    namespace Ns1.Foo
    {
        class Foo
        {
            public void Foo1()
            {
                
            }
        }
    }
    
    namespace Ns1.Foo.Bar
    {
        class Bar
        {
            public void Bar2()
            {
                Foo  f = new Foo();
            }
        }
    }
