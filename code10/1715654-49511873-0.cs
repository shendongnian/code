    public interface INode {
       string Name { get; set; }
       string Description { get; set; }
    }
    
    class Node : INode {
       public string Name { get; set; }
       public string Description { get; set; }
    }
    
    class StructuredNode : INode {
       public string Name { get; set; }
       public string Description { get; set; }
       public List<INode> Children { get; set; }
    }
