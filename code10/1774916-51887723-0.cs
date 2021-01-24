    public class Node
    {
        public Node() // you could pass nothing and set them manually or use the object initializer pattern
        {
        }
        public Node(string name, List<Node> nodes) // you could pass the name and an existing list
        {
            this.Name = name;
            this.Nodes = nodes;
        }
        public Node(string name, params Node[] nodes) // you could pass the name and a list of items (which can be called like Node("a", node, node, node)
        {
            this.Name = name;
            this.Nodes = nodes.ToArray(); // needs    using System.Linq;    at the top of the file or namespace
        }
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }
    }
