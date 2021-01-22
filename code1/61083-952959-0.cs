    namespace Foo
    {
        class Bar
        {
        }
    }
    
    namespace Bar
    {
        class Foo
        {
            static void DoIt()
            {
                 // Foo.Bar x1; // This wont compile.
                global::Foo.Bar x2; // This will compile.            
            }
        }
    }
