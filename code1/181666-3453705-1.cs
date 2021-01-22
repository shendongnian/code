    public class BindingNode
    {
        private List<BindingNode> _children = new List<BindingNode>();
    
        public IEnumerable<BindingNode> Children
        {
            get { return _children; }
        }
    
        public BindingNode Parent
        {
            get;
            private set;
        }
    
        public void AddChild( BindingNode node )
        {
            node.Parent = this;
            _children.Add( node );
        }
    }
