c#
    static class Program
    {
        static async Task Main(string[] args)
        {
            using (var archive = ZipFile.OpenRead(args[0]))
            {
                var entry = archive.Entries.Where(_ => _.FullName.Equals("USA-road-d.CAL.gr", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (entry != null)
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var data = new List<string>(Decompress(entry.Open()));
                    var graph = new Graph(data);
                    stopwatch.Watch();
                    Console.ReadLine();
                }
            }
        }
        public static IEnumerable<string> Decompress(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.ASCII))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
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
            Dictionary<int, Node> _nodes { get; } = new Dictionary<int, Node>();
            readonly Parameters _parameters;
            readonly List<Edge> _edges;
            readonly List<string> _comments;
            public IParameters Parameters => _parameters;
            public IEnumerable<Edge> Edges => _edges;
            public IEnumerable<string> Comments => _comments;
            public Node GetNode(int index) => _nodes.ContainsKey(index) ? _nodes[index] : (_nodes[index] = new Node(this, index));
            public Graph(IEnumerable<string> lines, bool isDirectional = false)
            {
                IEnumerable<string> parameters = new List<string>(lines.Where(_ => _[0] == 'p'));
                IEnumerable<string> edges = new List<string>(lines.Where(_ => _[0] == 'a'));
                IEnumerable<string> comments = new List<string>(lines.Where(_ => _[0] == 'c'));
                _parameters = 
                    parameters
                    .Select(_ => _.Split(' '))
                    .Select(_ => _[1] == "sp" ? new Parameters(int.Parse(_[2]), int.Parse(_[3])) : null).FirstOrDefault();
                _edges =
                    edges
                    .Select(_ => _.Split(' '))
                    .Select(_ => new Edge(this, GetNode(int.Parse(_[1])), GetNode(int.Parse(_[2])), int.Parse(_[3]), isDirectional))
                    .ToList();
                _comments =
                    comments
                    .Select(_ => _.Substring(1)).ToList();
                if (_parameters.Nodes != _nodes.Keys.Count)
                {
                    throw new Exception("invalid nodes count");
                }
                if (_parameters.Edges != _edges.Count)
                {
                    throw new Exception("invalid edges count");
                }
            }
        }
        public interface IParameters
        {
            int Nodes { get; }
            int Edges { get; }
        }
        public class Parameters: IParameters
        {
            public int Nodes { get; }
            public int Edges { get; }
            public Parameters(int nodes, int edges)
            {
                Nodes = nodes;
                Edges = edges;
            }
        }
    }
    public static class StopwatchExtensions
    {
        public static void Watch(this Stopwatch stopwatch, string message = "",
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0) =>
        Console.WriteLine(
            $"{stopwatch.Elapsed} " +
            $"{message} " +
            $"{memberName} " +
            $"{sourceFilePath}:{sourceLineNumber}");
    }
  [1]: https://i.stack.imgur.com/vBQGP.png
