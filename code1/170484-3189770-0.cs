    class Foo : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string value in new[] { "a", "b", "c" })
            {
                yield return value;
            }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
