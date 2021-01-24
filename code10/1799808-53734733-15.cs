    public class DirectedGraph<T>
    {
        private readonly HashSet<T> nodes = new HashSet<T>();
        private readonly MultiDictionary<T, T> edges = new MultiDictionary<T, T>();
        public void AddNode(T node) => nodes.Add(node);
        public void AddEdge(T n1, T n2)
        {
            AddNode(n1);
            AddNode(n2);
            edges.Add(n1, n2);
        }
        public void RemoveEdge(T n1, T n2) => edges.Remove(n1, n2);
        public void RemoveNode(T n)
        {
            // TODO: This algorithm is very inefficient if the graph is
            // TODO: large; can you think of ways to improve it?
            // Remove the incoming edges
            foreach (T n1 in nodes)
                RemoveEdge(n1, n);       
            // Remove the outgoing edges
            foreach (T n2 in edges.GetValues(n).ToList())
                RemoveEdge(n, n2);
            // The node is now isolated; remove it.
            nodes.Remove(n);
        }
        public IEnumerable<T> Edges(T n) => edges.GetValues(n);
        public IEnumerable<T> Nodes() => nodes.Select(x => x);
        public HashSet<T> ReachableNodes(T n) { ??? }
        // We'll come back to this one!
    }
