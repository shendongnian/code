    public class SingleLinkedListNode<T>
    {
        private readonly T value;
        private SingleLinkedListNode<T> next;
        public SingleLinkedListNode(T value, SingleLinkedListNode<T> next)
        {
            this.value = value;
        }
        public SingleLinkedListNode(T value, SingleLinkedListNode<T> next)
            : this(value)
        {
            this.next = next;
        }
        public SingleLinkedListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public T Value
        {
            get { return value; }
        }
    }
