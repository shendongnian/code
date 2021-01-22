    public interface INode<T> 
    {
        // Properties
        INode<T> Parent { get; }
        IEnumerable<INode<T>> Children { get; }
        String Key { get; }
        
        void AddChild(INode<T> child);
    }
    public class Node<T> : INode<T>
    {
        public Node(String key) : this(key, null) {}
        public Node(String key, INode<T> parent)
        {
            this.Parent = parent;
            this.Children = new List<T>();
            this.Key = key; 
        }
        public virtual INode<T> Parent { get; protected set; }
        public virtual String Key { get; protected set; }
        public virtual List<T> Children { get; protected set; }
        public void AddChild(INode<T> node) 
        {
            this.Children.Add(node);
        }
    }
