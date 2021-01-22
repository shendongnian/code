    class Program
    {
        static void Main(string[] args)
        {
            FastConcat<int> i = new FastConcat<int>();
            i.Add(new int[] { 0, 1, 2, 3, 4 });
            Console.WriteLine(i[0]);
            i.Add(new int[] { 5, 6, 7, 8, 9 });
            Console.WriteLine(i[4]);
            Console.WriteLine("Enumerator:");
            foreach (int val in i)
                Console.WriteLine(val);
            Console.ReadLine();
        }
    }
    class FastConcat<T> : IEnumerable<T>
    {
        LinkedList<T[]> _items = new LinkedList<T[]>();
        int _count;
        public int Count
        {
            get
            {
                return _count;
            }
        }
        public void Add(T[] items)
        {
            if (items == null)
                return;
            if (items.Length == 0)
                return;
            _items.AddLast(items);
            _count += items.Length;
        }
        private T[] GetItemIndex(int realIndex, out int offset)
        {
            offset = 0; // Offset that needs to be applied to realIndex.
            int currentStart = 0; // Current index start.
            foreach (T[] items in _items)
            {
                currentStart += items.Length;
                if (currentStart > realIndex)
                    return items;
                offset = currentStart;
            }
            return null;
        }
        public T this[int index]
        {
            get
            {
                int offset;
                T[] i = GetItemIndex(index, out offset);
                return i[index - offset];
            }
            set
            {
                int offset;
                T[] i = GetItemIndex(index, out offset);
                i[index - offset] = value;
            }
        }
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T[] items in _items)
                foreach (T item in items)
                    yield return item;
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
