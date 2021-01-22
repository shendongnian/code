    class Program
    {
        static void Main(string[] args)
        {
            var parent = 
                new TreeNode( "Parent", "desc", new TreeNode[] { 
                    new TreeNode( "Child 1", "desc1", new TreeNode[] { 
                        new TreeNode( "Grandchild 1", "desc1" ) } ),
                    new TreeNode( "Child 2", "desc2" ) } );
        }
    }
    class TreeNode
    {
        public TreeNode(string name, string description, IEnumerable<TreeNode> children)
            : this(name, description)
        {
            _children.AddRange(children);
        }
        public TreeNode(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TreeNode> Children
        {
            get
            {
                return _children.AsReadOnly();
            }
            set
            {
                _children.Clear();
                _children.AddRange(value);
            }
        }
        private List<TreeNode> _children = new List<TreeNode>();
    }
