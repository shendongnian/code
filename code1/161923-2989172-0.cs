    abstract class Node
    {
        public Node(Stream stream) { InitializeFrom(stream); }
        protected Node() { }
        protected void InitializeFrom(Stream stream);
    }
    class FilesystemNode
    {
        public FilesystemNode(FileStream stream) : base(stream) {}
    }
    class CompositeNode
    {
        public CompositeNode(IEnumerable values) : base()
        {
            using (var stream = new MemoryStream())
            {
                // init stream
                InitializeFrom(stream);
            }
        }
    }
