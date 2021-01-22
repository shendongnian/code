    namespace MyService
    {
        partial class foo
        {
            public static implicit operator MyFramework.foo(foo input)
            {
                return new MyFramework.foo
                {
                    PropertyA = input.PropertyA,
                    PropertyB = input.PropertyB,
                    PropertyC = input.PropertyC,
                    // ...
                };
            }
        }
    }
