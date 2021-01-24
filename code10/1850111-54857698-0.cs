c#
        public class Edge
        {
            public Edge(Graph graph, Node v1, Node v2, int distance, bool isDirectional = false)
            {
                Graph = graph;
                V1 = v1;
                V2 = v2;
                Distance = distance;
                v1.AddEdge(this);
                if (!IsDirectional)
                    v2.AddEdge(this);
            }
            internal Graph Graph { get; }
            public Node V1 { get; }
            public Node V2 { get; }
            public int Distance { get; }
            public bool IsDirectional { get; }
        }
        public class Node
        {
            static int counter = 0;
            readonly List<Edge> _edges = new List<Edge>();
            public Node(Graph graph, int index)
            {
                Graph = graph;
                Index = index;
                Number = counter++;
            }
            internal Graph Graph { get; }
            public int Index { get; }
            public int Number { get; }
            public IEnumerable<Edge> Edges => _edges;
            public void AddEdge(Edge edge) => _edges.Add(edge);
        }
        public class Graph
        {
            readonly List<Edge> _edges;
            public IEnumerable<Edge> Edges => _edges;
            public Dictionary<int, Node> Nodes { get; } = new Dictionary<int, Node>();
            public Node GetNode(int index) => Nodes.ContainsKey(index) ? Nodes[index] : (Nodes[index] = new Node(this, index));
            public Graph(string fileName, bool isDirectional = false) => _edges = 
                File.ReadAllLines(fileName)
                .Select(s => s.Split(' '))
                .Select(_ => new Edge(this, GetNode(int.Parse(_[1])), GetNode(int.Parse(_[2])), int.Parse(_[3]), isDirectional))
                .ToList();
            public int[,] ToConnectivityMatrix()
            {
                int nodesCount = Nodes.Keys.Count;
                int[,] connectivityMatrix = new int[nodesCount, nodesCount];
                foreach (var edge in _edges)
                {
                    connectivityMatrix[edge.V1.Number, edge.V2.Number] = edge.Distance;
                }
                return connectivityMatrix;
            }
        }
