    public class BindingNode
    {
        private BindingNode _parent;
        private List<BindingNode> _children = new List<BindingNode>();
    
        public IEnumerable<BindingNode> Children
        {
            get { return _children; }
        }
    
        public BindingNode Parent
        {
            get { return _parent; }
        }
    
        public void AddChild( BindingNode node )
        {
            node._parent = this;
            _children.Add( node );
        }
    }
