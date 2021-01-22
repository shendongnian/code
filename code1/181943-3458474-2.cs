    class Node
        {
        public Node()
        {
            Children = new List<Node>();
        }
        public IEnumerable<Node> GetSubTree()
        {
            return Children.SelectMany(c => c.GetSubTree()).Concat(new[] { this });
            //Post-order traversal
        }
        public List<Node> Children { get; set; }
    }
    class Tree
    {
        public Tree()
        {
            Roots = new List<Node>();
        }
        public IEnumerable<Node> GetAllNodes()
        {
            return Roots.SelectMany(root => root.GetSubTree());
        }
        List<Node> Roots { get; set; }
    }
