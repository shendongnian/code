        public class UniqueList<T> : List<T>
        {
            private HashSet<T> _internalHash = new HashSet<T>();
            public UniqueList() : base() { }
            public UniqueList(IEnumerable<T> collection) : base(collection) { }
            public UniqueList(int capacity) : base(capacity) { }
            public new void Add(T item)
            {
                if (!_internalHash.Add(item))
                    throw new ArgumentException("Item already exists in UniqueList");
                base.Add(item);
            }
            public new void AddRange(IEnumerable<T> collection)
            {
                foreach (T t in collection)
                {
                   this.Add(t);
                }
            }
            public new bool Remove(T item)
            {
                _internalHash.Remove(item);
                return base.Remove(item);               
            }
            public new int RemoveAll(Predicate<T> match)
            {
                int removedElems = 0;
                foreach (T item in this)
                {
                    if (match(item))
                    {
                        this.Remove(item);
                        removedElems++;
                    }
                }
                return removedElems;
            }
            public new void RemoveAt(int index)
            {                
               this.Remove(this[index]);             
            }
            public new void RemoveRange(int index, int count)
            {
                for (int i = index; i < count; i++)
                {
                    this.Remove(this[i]);
                }
            }
        }
