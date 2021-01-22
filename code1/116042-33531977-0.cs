    public class NullTester<T>
    {
        public bool IsNull(T value)
        {
            return (value == null);
        }
    }
If the compiler didn't accept comparisons against null for value types, then it would essentially break this class, having an implicit constraint attached to its type parameter (i.e. it would only work with non-value-based types).
