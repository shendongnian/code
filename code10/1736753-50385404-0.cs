    public static class ListExtensions
    {       
        public static IndexedListEnumerator<T> GetIndexedListEnumerator(this IList<T> list) =>
            new IndexedListEnumerator<T>(list);
    }
    public sealed class IndexedListEnumerator<T> : IEnumerator<T>
    {
        private readonly IList<T> list;
        // You *could* restrict this to the range [-1, list.Count] if you wanted.
        public int Index { get; set; }
        // You might want to make this public
        private bool IndexIsValid => Index >= 0 && Index < list.Count;
        public IndexedListEnumerator(IList<T> list)
        {
            this.list = list;
            Index = -1; // Before the first element
        }
        // TODO: Consider using checked to throw an exception around int.MaxValue
        public bool MoveNext()
        {
            Index++;
            return IndexIsValid;
        }
        public bool MovePrevious()
        {
            Index--;
            return IndexIsValid;
        }
        public T Current => list[Index];
        object IEnumerator.Current => Current;
        void IDisposable.Dispose() {}
    }
