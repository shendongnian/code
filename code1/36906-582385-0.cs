    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Previous { get; set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> Last { get; private set; }
        public LinkedListNode<T> AddLast(T value)
        {
            return Last = new LinkedListNode<T> {
                Value = value,
                Previous = Last
            };
        }
        public IEnumerator<T> GetEnumerator()
        {
            var walk = Last;
            while (walk != null) {
                yield return walk.Value;
                walk = walk.Previous;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
