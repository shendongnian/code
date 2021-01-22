    public class Node<T>
    {
        public T Value { get; private set; }
        public IList<Node<T>> Children { get; private set; }
    
        public Node(T value, IEnumerable<Node<T>> children)
        {
            this.Value = value;
            this.Children = new List<Node<T>>(children);
        }
    }
