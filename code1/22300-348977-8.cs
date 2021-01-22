    public class Foo : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "x";
            yield return "y";
        }
 
        // Explicit interface implementation for nongeneric interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Just return the generic version
        }
    }
