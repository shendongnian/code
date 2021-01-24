    public class SortedListFixed<TKey, TValue> : SortedList<TKey, TValue>
    {
        private SortedList<TKey, TValue> _list;
        public bool IsFixedSize => true;
    
        /** ctors **/
        public void Add(TKey key, TValue value) => 
            throw InvalidOperationException("This collection is fixed size");
        public bool Remove (TKey key) =>
            throw InvalidOperationException("This collection is fixed size");
        /** etc. for all inherited size-modifying methods **/
    }
