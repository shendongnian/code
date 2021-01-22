        public class CircularDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        {
            private Queue<TKey> m_ItemInsertList = new Queue<TKey>();
            private int m_ItemsToHold = 100;
            public int ItemsToHold
            {
                get { return m_ItemsToHold; }
                set {
                    if (value < 1)
                        throw new ArgumentException("Items to hold must be at least 1");
                    m_ItemsToHold = value; 
                }
            }
            public new void Add(TKey key, TValue value)
            {
                base.Add(key, value);
                if (m_ItemInsertList.Count == m_ItemsToHold)
                    base.Remove(m_ItemInsertList.Dequeue());
                m_ItemInsertList.Enqueue(key);
            }
        }
