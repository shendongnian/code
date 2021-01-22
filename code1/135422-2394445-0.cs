    public class ReadOnlyCollection<T> : IList<T>
    {
        public void IList<T>.Insert(int index, T item)
        {
            throw new NotSupportedException();
        }
        /* ... rest of IList<T> implemented normally */
    }
