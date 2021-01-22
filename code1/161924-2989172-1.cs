    abstract class Node
    {
        NodeKind kind;
        public Node(NodeKind kind) { this.kind = kind; }
        public NodeKind Kind { get { return kind; } }
        static Node ReadFrom(Stream stream);
    }
    class FilesystemNode : Node
    {
        string filename;
        public FilesystemNode(string filename) : Node(NodeKind.Filesystem)
        {
            this.filename = filename;
        }
        public string Filename { get { return filename; } }
        static FilesystemNode ReadFrom(FileStream stream);
    }
    class CompositeNode : Node
    {
        Node[] values;
        // I'm assuming IEnumerable<Node> here, but you can store whatever.
        public CompositeNode(IEnumerable<Node> values) : Node(NodeKind.Composite)
        {
            this.values = values.ToArray();
        }
        public IEnumerable<Node> { get { return filename; } }
    }
