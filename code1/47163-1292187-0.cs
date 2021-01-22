    public class EnumerableGenericizer<T> : IEnumerable<T>
    {
        public IEnumerable Target { get; set; }
        public EnumerableGenericizer(IEnumerable target)
        {
            Target = target;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in Target)
            {
                yield return item;
            }
        }
    }
