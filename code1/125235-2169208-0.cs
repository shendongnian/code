    public class Node
    {
       public Node Parent { get; private set; }
       public IEnumerable<Node> Children { get; private set; }
       public bool HasChildren { get { return Children.Count() > 0; } }
       public Node()
       {
          Children = new List<Node>();
       }
    }
