    public class Foo : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            ...
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Call to the generic version
        }
    }
