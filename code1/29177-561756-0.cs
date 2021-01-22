    public class SingleEnumerator<T> : IEnumerable<T>
    {
        private readonly T m_Value;
        public SingleEnumerator(T value)
        {
            m_Value = value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return m_Value;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return m_Value;
        }
    }
