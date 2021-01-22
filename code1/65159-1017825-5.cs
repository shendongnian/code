    class X 
    {
        // 'Outer.Foo' is inaccessible due to its protection level
        private void Flibble(Outer.Foo foo)
        {
        }
    }
    class X : Outer
    {
        // fine
        private void Flibble(Outer.Foo foo)
        {
        }
    }
