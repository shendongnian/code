    public class Foo : IEnumerable<T>
    {
        // Implicit interface implementation
        public IEnumerator<T> GetEnumerator()
        {
            // Real work
        }
        // Explicit interface implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Calls method above
        }
    }
