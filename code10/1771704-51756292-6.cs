    public class TreeNode<T>
    {
        public T Data { get; set; }
        private List<TreeNode<T>> _children = new List<TreeNode<T>>();
        public IEnumerable<TreeNode<T>> Children => _children;
        public TreeNode<T> AddChild(T data)
        {
            var node = new TreeNode<T>{ Data = data };
            _children.Add(node);
            return node;
        }
    }
    public class Tree<T>
    {
        public TreeNode<T> Root { get; } = new TreeNode<T>();
    }
