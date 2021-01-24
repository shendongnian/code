    public abstract class Node
    {
    }
    public class TextNode : Node
    {
        public string Value { get; set; }
    }
    public class Expression : Node
    {
        public Node[] Nodes { get; set; }
    }
