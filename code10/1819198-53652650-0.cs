    public class Graph : IGraph
    {
        private HashSet<INode> _nodes = new HashSet<INode>(); 
        private HashSet<IEdge> _edges = new HashSet<IEdge>();
    
        public IEnumerable<INode> Nodes => _nodes;
        public IEnumerable<IEdge> Edges => _edges;
    
        public void AddNode(INode node) => _nodes.Add(node); //Here you can extend with your own custom code.
        public void AddEdge(IEdge edge) => _edges.Add(edge);
        //Here you add other functions such as perhaps "Remove".
    }
