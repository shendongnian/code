    using Bar;
    
    namespace Foo
    {
        using Bar;
    
        namespace Bar
        {
            class C
            {
            }
    
        }
    
        namespace Baz
        {
            class D
            {
                C c = new C();
            }
        }
    }
    
    namespace Bar
    {
        class E
        {
        }
    }
