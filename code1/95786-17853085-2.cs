    public class OrderedSet<T> : ISet<T>
    {
        private readonly IDictionary<T, LinkedListNode<T>> m_Dictionary;
        private readonly LinkedList<T> m_LinkedList;
        public OrderedSet()
        {
            m_Dictionary = new Dictionary<T, LinkedListNode<T>>();
            m_LinkedList = new LinkedList<T>();
        }
        public bool Add(T item)
        {
            if (m_Dictionary.ContainsKey(item)) return false;
            var node = m_LinkedList.AddLast(item);
            m_Dictionary.Add(item, node);
            return true;
        }
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }
        public void Clear()
        {
            m_LinkedList.Clear();
            m_Dictionary.Clear();
        }
        public bool Remove(T item)
        {
            LinkedListNode<T> node;
            bool found = m_Dictionary.TryGetValue(item, out node);
            if (!found) return false;
            m_Dictionary.Remove(item);
            m_LinkedList.Remove(node);
            return true;
        }
        public int Count
        {
            get { return m_Dictionary.Count; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return m_LinkedList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool Contains(T item)
        {
            return m_Dictionary.ContainsKey(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            m_LinkedList.CopyTo(array, arrayIndex);
        }
        public virtual bool IsReadOnly
        {
            get { return m_Dictionary.IsReadOnly; }
        }
        public void UnionWith(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public void IntersectWith(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public void ExceptWith(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public bool Overlaps(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        public bool SetEquals(IEnumerable<T> other)
        {
            throw GetNotSupportedDueToSimplification();
        }
        private static Exception GetNotSupportedDueToSimplification()
        {
            return new NotSupportedException("This method is not supported due to simplification of example code.");
        }
    }
