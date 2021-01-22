    class SortedList<T> : List<T>
    {
        public new void Add(T item)
        {
            Insert(~BinarySearch(item), item);
        }
    }
