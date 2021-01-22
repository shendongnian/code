    public class TreeNode<TValue>
    {
        #region Properties
        public TValue Value { get; set; }
        public List<TreeNode<TValue>> Children { get; private set; }
        public bool HasChild { get { return Children.Any(); } }
        #endregion
        #region Constructor
        public TreeNode()
        {
            this.Children = new List<TreeNode<TValue>>();
        }
        public TreeNode(TValue value)
            : this()
        {
            this.Value = value;
        }
        #endregion
        #region Methods
        public void AddChild(TreeNode<TValue> treeNode)
        {
            Children.Add(treeNode);
        }
        public void AddChild(TValue value)
        {
            var treeNode = new TreeNode<TValue>(value);
            AddChild(treeNode);
        }
        #endregion
    }
