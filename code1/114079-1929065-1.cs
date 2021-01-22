    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
            Children = new List<Node<T>>();
        }
        public T Data { get; private set; }
        public ICollection<Node<T>> Children { get; private set; }
    }
