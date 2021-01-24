    class Graph
    {
        private List<Node> nodes;
        public ReadOnlyCollection<Node> Nodes
        {
            get { return new ReadOnlyCollection<Node>(nodes); }
            //note no setter
        }
        public void AddNode(Node node) { nodes.Add(node); }
    }
