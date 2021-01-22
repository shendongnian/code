    class FooCollection : IEnumerable<Foo>, IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Foo> GetEnumerator()
        {
            // return enumerator
        }
    }
