    class Foo {}
    class FooCollection : Collection<Foo>
    {
        protected override void InsertItem(int index, Foo item)
        {
            // your code...
            base.InsertItem(index, item);
        }
        protected override void SetItem(int index, Foo item)
        {
            // your code...
            base.SetItem(index, item);
        }
        // etc
    }
