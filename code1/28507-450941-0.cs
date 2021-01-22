     public class SortedContainer<T> : IList<T> where T : IComparable<T>
        {
            private List<T> internalList = new List<T>();
    
            public int IndexOf(T item)
            {
                return internalList.IndexOf(item);
            }
    
            public void Insert(int index, T item)
            {
                internalList.Insert(index, item);
            }
    
            public void RemoveAt(int index)
            {
                internalList.RemoveAt(index);
            }
    
            public T this[int index]
            {
                get
                {
                    return internalList[index];
                }
                set
                {
                    internalList[index] = value;
                }
            }
    
            public void Add(T item)
            {
                internalList.Add(item);
                this.Sort();
            }
    
            public void Clear()
            {
                internalList.Clear();
            }
    
            public bool Contains(T item)
            {
                return internalList.Contains(item);
            }
    
            public void CopyTo(T[] array, int arrayIndex)
            {
                internalList.CopyTo(array, arrayIndex);
            }
    
            public int Count
            {
                get { return internalList.Count; }
            }
    
            public bool IsReadOnly
            {
                get { return false; }
            }
    
            public bool Remove(T item)
            {
                bool result = internalList.Remove(item);
                this.Sort();
                return result;
            }
    
    
    
            public IEnumerator<T> GetEnumerator()
            {
                return internalList.GetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return internalList.GetEnumerator();
            }
    
            private void Sort()
            {
                internalList.Sort();
            }
    
            private List<T> GetCopy()
            {
                return internalList.ToList();
            }
    
            public int GetSortedIndex(T item)
            {
                List<T> copy = GetCopy();
                copy.Add(item);
                copy.Sort();
                return copy.IndexOf(item);
            }
    
        }
