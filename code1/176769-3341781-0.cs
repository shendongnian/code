    public class Node
    {
        List<Node> children;
        public string Text { get; set; }
        public List<Node> Children { get { return children ?? (children = new List<Node>()); } }
    }
