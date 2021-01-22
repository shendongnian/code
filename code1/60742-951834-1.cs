    public class Node<T>
    {
        public T DataObject { get; private set; }
        public IList<Node<T>> Children { get; private set; }
    
        public Node(T dataObject, IEnumerable<Node<T>> children)
        {
            this.DataObject = dataObject;
            this.Children = new List<Node<T>>(children);
        }
    }
