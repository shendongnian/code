    class Outer
    {
        private void Foo()
        {
            Nested nested = new Nested("bar");
        }
        class Nested
        {
            internal Nested(string x)
            {
                ...
            }
        }
    }
