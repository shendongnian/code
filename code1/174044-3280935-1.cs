    namespace Some.Other.Namespace
    {
        class SecondClass
        {
            void SomeMethod()
            {
                Some.Namespace.FirstClass temp = new Some.Namespace.FirstClass();
                temp.SomeValue = "test";
            }
        }
    }
