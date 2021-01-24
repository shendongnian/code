    public class TreeNode<T>
    {
        public T Data { get; set; }
        private List<TreeNode<T>> _children = new List<TreeNode<T>>();
        public IEnumerable<TreeNode<T>> Children => _children;
        public TreeNode<T> AddChild(T data)
        {
            var node = new TreeNode<T> { Data = data };
            _children.Add(node);
            return node;
        }
        public void VisitPreOrder(Action<T, int> action, int level)
        {
            action(Data, level);
            foreach (TreeNode<T> node in Children) {
                node.VisitPreOrder(action, level + 1);
            }
        }
    }
    public class Tree<T>
    {
        public TreeNode<T> Root { get; } = new TreeNode<T>();
        public void VisitPreOrder(Action<T, int> action)
        {
            Root.VisitPreOrder(action, 0);
        }
    }
