        public class OrderedSet<T> : ISet<T>
        {
            private readonly ISet<T> m_Set;
            private readonly Stack<WeakReference> m_Stack;
            private int m_GarbageCounter;
            public OrderedSet()
                : this(new HashSet<T>())
            {
            }
            public OrderedSet(ISet<T> set)
            {
                m_Set = set;
                if (set.Count != 0)
                    throw new NotSupportedException("Only an empty set can be decorated into an ordered set.");
                m_Stack = new Stack<WeakReference>();
                m_GarbageCounter = 0;
            }
            public bool Add(T item)
            {
                var itemRef = new WeakReference(item);
                m_Stack.Push(itemRef);
                return m_Set.Add(item);
            }
            void ICollection<T>.Add(T item)
            {
                Add(item);
            }
            public void Clear()
            {
                m_Stack.Clear();
                m_Set.Clear();
                m_GarbageCounter = 0;
            }
            public bool Remove(T item)
            {
                m_GarbageCounter++;
                Reorganize();
                return m_Set.Remove(item);
            }
            public int Count
            {
                get { return m_Set.Count; }
            }
            private void Reorganize()
            {
                var twentyPercentOfOverallSize = Count/10;
                if (m_GarbageCounter < twentyPercentOfOverallSize) return;
                var temporaryOrderedArray = this.ToArray();
                m_Stack.Clear();
                foreach (var element in temporaryOrderedArray)
                {
                    m_Stack.Push(new WeakReference(element));
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                return
                    m_Stack
                        .Where(itemRef => itemRef.IsAlive)
                        .Select(itemRef => itemRef.Target)
                        .Cast<T>()
                        .Where(item => Contains(item))
                        .GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public bool Contains(T item)
            {
                return m_Set.Contains(item);
            }
            public void CopyTo(T[] array, int arrayIndex)
            {
                m_Set.CopyTo(array, arrayIndex);
            }
            public virtual bool IsReadOnly
            {
                get { return m_Set.IsReadOnly; }
            }
            public void UnionWith(IEnumerable<T> other)
            {
                ThrowNotSupportedDueToSimplification();
            }
            public void IntersectWith(IEnumerable<T> other)
            {
                ThrowNotSupportedDueToSimplification();
            }
            public void ExceptWith(IEnumerable<T> other)
            {
                ThrowNotSupportedDueToSimplification();
            }
            public bool IsSubsetOf(IEnumerable<T> other)
            {
                return m_Set.IsSubsetOf(other);
            }
            public void SymmetricExceptWith(IEnumerable<T> other)
            {
                ThrowNotSupportedDueToSimplification();
            }
            public bool IsSupersetOf(IEnumerable<T> other)
            {
                return m_Set.IsSupersetOf(other);
            }
            public bool IsProperSupersetOf(IEnumerable<T> other)
            {
                return m_Set.IsProperSupersetOf(other);
            }
            public bool IsProperSubsetOf(IEnumerable<T> other)
            {
                return m_Set.IsProperSubsetOf(other);
            }
            public bool Overlaps(IEnumerable<T> other)
            {
                return m_Set.Overlaps(other);
            }
            public bool SetEquals(IEnumerable<T> other)
            {
                return m_Set.SetEquals(other);
            }
            private static void ThrowNotSupportedDueToSimplification()
            {
                throw new NotSupportedException("This method is not supported due to simplification of example code.");
            }
        }
