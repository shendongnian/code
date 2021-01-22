    class Foo : IEnumerable<object>{
        // explicitly implement IEnumerable.GetEnumerator()
        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator();
        }
        public IEnumerator<object> GetEnumerator ()
        {
            yield break;
        }
    }
