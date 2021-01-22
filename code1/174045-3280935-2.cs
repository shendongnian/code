    using Some.Namespace;
    namespace Some.Other.Namespace
    {
        class SecondClass
        {
            void SomeMethod()
            {
                // note how the namespace is not needed here:
                FirstClass temp = new FirstClass();
                temp.SomeValue = "test";
            }
        }
    }
