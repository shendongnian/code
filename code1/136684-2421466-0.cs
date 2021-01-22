    public sealed class LinkedListNode<T>
    {
        public LinkedListNode<T> Next { get; }
        public LinkedListNode<T> Previous { get; }
        public T Value { get; set; }
    }
