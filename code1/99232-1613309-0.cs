    class EnumeratorWrapper<T> : IEnumerable<T>
    {
        Func<IEnumerator<T>> m_generator;
        public EnumeratorWrapper(Func<IEnumerator<T>> generator)
        {
            m_generator = generator;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return m_generator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_generator();
        }
    }
