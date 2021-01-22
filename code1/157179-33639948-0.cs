    namespace TopologyDAL
    {
        public partial class Node
        {
            // Auto generated from EF
        }
    
        public partial class Node
        {
            public int Key { ... }
            private class NodeProxy : INode<int>
            {
                private readonly Node _node;
                public NodeProxy(Node node)
                {
                    _node = node;
                }
                public int Key { get { return _node.Key; } }
            }
            private readonly NodeProxy _nodeProxy;
            public Node()
            {
                _nodeProxy = new NodeProxy(this);
            }
        }
    }
