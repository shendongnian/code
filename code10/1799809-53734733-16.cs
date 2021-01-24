    public class UndirectedGraph<T>
    {
        private readonly DirectedGraph<T> g = new DirectedGraph<T>();
        public void AddNode(T node) => g.AddNode(node);
        public void AddEdge(T n1, T n2)
        {
            g.AddEdge(n1, n2);
            g.AddEdge(n2, n1);
        }
        public void RemoveEdge(T n1, T n2)
        {
            g.RemoveEdge(n1, n2);
            g.RemoveEdge(n2, n1);
        }
        public void RemoveNode(T n) => g.RemoveNode(n);
        public IEnumerable<T> Edges(T n) => g.Edges(n);
        public IEnumerable<T> Nodes() => g.Nodes();
    }
