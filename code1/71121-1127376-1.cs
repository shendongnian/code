    public class TreeNode<TValue> : IEnumerable<TreeNode<TValue>>
    {
        private List<TreeNode<TValue>> _children = new List<TreeNode<TValue>>();
        public TreeNode<TValue> Parent { get; private set; }
        public void Add(TreeNode<TValue> child)
        {
            _children.Add(child);
            child.Parent = this;
        }
        public void Remove(TreeNode<TValue> child)
        {
            _children.Remove(child);
            child.Parent = null;
        }
        public IEnumerator<TreeNode<TValue>> GetEnumerator()
        {
            return _children.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children.GetEnumerator();
        }      
    }
