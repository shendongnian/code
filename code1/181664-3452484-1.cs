    public class BoundNode : INode
    {
        private INode _thisNode { get; private set; }
        public INode Parent { get; private set; }
        public BoundNode(INode bindingNode, INode parent)
        {
            _thisNode = bindingNode;
            Parent = parent;
        }
        // Implement pass throughs to the _thisNode member
            
    }
