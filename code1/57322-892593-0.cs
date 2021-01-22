    public class ItemChangedArgs<T> : EventArgs
    {
        public int Index { get; set; }
        public T Item { get; set; }
    }
    public class EventList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private List<T> m_list;
        public event EventHandler<ItemChangedArgs<T>> ItemAdded;
        public event EventHandler<ItemChangedArgs<T>> ItemRemoved;
        public event EventHandler<ItemChangedArgs<T>> ItemChanged;
        public event EventHandler ListCleared;
        public EventList(IEnumerable<T> collection)
        {
            m_list = new List<T>(collection);
        }
        public EventList(int capacity)
        {
            m_list = new List<T>(capacity);
        }
        public EventList()
        {
            m_list = new List<T>();
        }
        public void Add(T item)
        {
            Add(item, true);
        }
        public void Add(T item, Boolean raiseEvent)
        {
            m_list.Add(item);
            if (raiseEvent) RaiseItemAdded(this.Count - 1, item);
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T t in collection)
            {
                m_list.Add(t);
            }
        }
        private void RaiseItemAdded(int index, T item)
        {
            if (ItemAdded == null) return;
            ItemAdded(this, new ItemChangedArgs<T> { Index = index, Item = item });
        }
        public int IndexOf(T item)
        {
            return m_list.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            m_list.Insert(index, item);
            RaiseItemAdded(index, item);
        }
        public void RemoveAt(int index)
        {
            T item = m_list[index];
            m_list.RemoveAt(index);
            RaiseItemRemoved(index, item);
        }
        private void RaiseItemRemoved(int index, T item)
        {
            if(ItemRemoved == null) return;
            ItemRemoved(this, new ItemChangedArgs<T> { Index = index, Item = item });
        }
        public T this[int index]
        {
            get { return m_list[index]; }
            set 
            { 
                m_list[index] = value;
                RaiseItemChanged(index, m_list[index]);
            }
        }
        private void RaiseItemChanged(int index, T item)
        {
            if(ItemChanged == null) return;
            ItemChanged(this, new ItemChangedArgs<T> { Index = index, Item = item });
        }
        public void Clear()
        {
            m_list.Clear();
            RaiseListCleared();
        }
        private void RaiseListCleared()
        {
            if(ListCleared == null) return;
            ListCleared(this, null);
        }
        public bool Contains(T item)
        {
            return m_list.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            m_list.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return m_list.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            for (int i = 0; i < m_list.Count; i++)
            {
                if(item.Equals(m_list[i]))
                {
                    T value = m_list[i];
                    m_list.RemoveAt(i);
                    RaiseItemRemoved(i, value);
                    return true;
                }
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return m_list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_list.GetEnumerator();
        }
    }
