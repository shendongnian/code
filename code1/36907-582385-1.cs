    public class LinkedListNode<T>
    {
        public LinkedList<T> Parent { get; set; }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> Last { get; private set; }
        public LinkedListNode<T> AddLast(T value)
        {
            Last = (Last == null)
                ? new LinkedListNode<T> { Previous = null }
                : Last.Next = new LinkedListNode<T> { Previous = Last };
            Last.Parent = this;
            Last.Value = value;
            Last.Next = null;
            return Last;
        }
        public void SevereAt(LinkedListNode<T> node)
        {
            if (node.Parent != this)
                throw new ArgumentException("Can't severe node that isn't from the same parent list.");
            node.Next.Previous = null;
            node.Next = null;
            Last = node;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var walk = Last;
            while (walk != null) {
                yield return walk.Value;
                walk = walk.Previous;
            }
        }
    }
